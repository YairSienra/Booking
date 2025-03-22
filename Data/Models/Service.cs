using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Service : BaseEntity
    {
        public string NameService { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
