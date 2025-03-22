using Contract.Request;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IBookingService
    {
        Task<IEnumerable<Service>> GettingServices();

        IEnumerable<Booking> GettingServicesReserved();

        Task<bool> PutBooking(PostBooking name);
    }
}
