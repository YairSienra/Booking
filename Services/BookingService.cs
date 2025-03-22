using Contract;
using Contract.Request;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly HolidaysContext _context;
        public BookingService(HolidaysContext context)
        {
            _context = context;
        }


        public virtual async Task<IEnumerable<Service>> GettingServices()
        {
            return await _context.Service.Include(x => x.Bookings).ToListAsync();
        }

        public virtual IEnumerable<Booking> GettingServicesReserved()
        {
            return _context.Booking.Where(x => x.Reserved == true);
        }


        public virtual async Task<bool> PutBooking(PostBooking request)
        {
            var service = await _context.Service
                .Include(s => s.Bookings)
                .FirstOrDefaultAsync(x => x.NameService == request.NameService);
            if (service == null)
                throw new Exception("Servicio no encontrado");

            var client = await _context.Client
                .Include(c => c.Bookings)
                .FirstOrDefaultAsync(c => c.Name == request.Name);
            if (client == null)
            {
                client = new Client { Name = request.Name, LastName = "" };
                _context.Client.Add(client);
                await _context.SaveChangesAsync();
                client = await _context.Client
                    .Include(c => c.Bookings)
                    .FirstOrDefaultAsync(c => c.Id == client.Id);
            }

            var requestedDate = request.Date.Date;
            var requestedTime = request.Date.TimeOfDay;
            var clientBookingForDate = client.Bookings
                .FirstOrDefault(b => b.Date.HasValue && b.Date.Value.Date == requestedDate);
            if (clientBookingForDate != null)
                throw new Exception("El mismo cliente ya tiene una reserva para este día");

            var reservationsToday = service.Bookings
                .Where(b => b.Reserved && b.Date.HasValue && b.Date.Value.Date == requestedDate);
            if (reservationsToday.Count() >= 2)
                throw new Exception("No es posible reservar hoy, el máximo es 2 reservas");

            var availableBooking = service.Bookings.FirstOrDefault(b =>
                !b.Reserved &&
                b.Date.HasValue &&
                b.Date.Value.Date == requestedDate &&
                b.Time == requestedTime);
            if (availableBooking == null)
                throw new Exception("No existe una reserva disponible para el mismo día y horario");

            availableBooking.Reserved = true;
            availableBooking.ClientId = client.Id;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
