using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    class Booking
    {
        public DateTime BookingDate { get; set; }
        public double TotalCost { get; set; }
        public int TotalTickets { get; set; }
        public List<Ticket> BookingTickets { get; set; }

        public Booking()
        {

        }
    }
}
