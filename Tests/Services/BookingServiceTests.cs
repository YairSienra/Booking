
using Contract.Request;
using Services;
using Tests.Helpers;
using Tests.Helpers.DataSets;

namespace Tests.Services
{
    [TestFixture]
    public class BookingServiceTests
    {
        [Test]
        public void When_GetAllServicesWithReservedOnFalse_Expected_AllServicesNotReserved()
        {
            using (var context = ContextHelper.GetContext(BookingReservesDataSet.ServicesOn()))
            {
                var service = new BookingService(context);
                var result = service.GettingServices().Result;
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.Count, Is.EqualTo(1));
                    Assert.That(result, Is.Not.Null);
                });
            }
        }

        [Test]
        public void When_NoServicesExist_Expected_EmptyList()
        {
            using (var context = ContextHelper.GetContext(BookingReservesDataSet.ServicesEmpty()))
            {
                var service = new BookingService(context);
                var result = service.GettingServices().Result;
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.Count, Is.EqualTo(0));
                });
            }
        }

        [Test]
        public void When_MultipleServicesExist_Expected_CorrectCount()
        {
            using (var context = ContextHelper.GetContext(BookingReservesDataSet.MultipleServices()))
            {
                var service = new BookingService(context);
                var result = service.GettingServices().Result;
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.Count, Is.EqualTo(3));
                });
            }
        }

        [Test]
        public async Task When_SameClientReservesTwice_Expected_Exception()
        {
            using (var context = ContextHelper.GetContext(BookingReservesDataSet.ServicesOn()))
            {
                var service = new BookingService(context);
                var request = new PostBooking
                {
                    Name = "TestClient",
                    NameService = "TestService",
                    Date = new DateTime(2025, 04, 01, 10, 0, 0)
                };

                Assert.DoesNotThrowAsync(async () => await service.PutBooking(request));


                var ex = Assert.ThrowsAsync<Exception>(async () => await service.PutBooking(request));
                Assert.That(ex.Message, Is.EqualTo("El mismo cliente ya tiene una reserva para este día"));
            }
        }

        [Test]
        public async Task When_ReservingWhenSlotAlreadyReserved_Expected_Exception()
        {
            using (var context = ContextHelper.GetContext(BookingReservesDataSet.ServicesOnButOneOnTrue()))
            {
                var service = new BookingService(context);
                var request = new PostBooking
                {
                    Name = "OtroCliente",
                    NameService = "TestService",
                    Date = new DateTime(2025, 04, 01, 15, 0, 0)
                };

                var ex = Assert.ThrowsAsync<Exception>(async () => await service.PutBooking(request));
                Assert.That(ex.Message, Is.EqualTo("No existe una reserva disponible para el mismo día y horario"));
            }
        }

        [Test]
        public async Task When_ReservingWithValidSlot_Expected_Success()
        {
            using (var context = ContextHelper.GetContext(BookingReservesDataSet.ServicesOn()))
            {
                var service = new BookingService(context);
                var request = new PostBooking
                {
                    Name = "NewClient",
                    NameService = "TestService",
                    Date = new DateTime(2025, 04, 01, 10, 0, 0)
                };

                var result = await service.PutBooking(request);
                Assert.That(result, Is.True);
            }
        }
    }
}
