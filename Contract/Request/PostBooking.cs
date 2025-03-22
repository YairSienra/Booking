using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request
{
    public class PostBooking
    {
        public string Name { get; set; }
        public string NameService { get; set; }
        public DateTime Date { get; set; }
    }
}
