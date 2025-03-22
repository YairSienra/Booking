using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Booking : BaseEntity
    {
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public bool Reserved { get; set; }

        [ForeignKey(nameof(Services))]
        public int IdService { get; set; }
        public Service? Services { get; set; }

        // Relación con Client
        [ForeignKey(nameof(Client))]
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
