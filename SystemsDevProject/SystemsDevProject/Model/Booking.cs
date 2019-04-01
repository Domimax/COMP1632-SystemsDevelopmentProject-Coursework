using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public double TotalCost { get; set; }
        public List<Ticket> BookingTickets { get; set; }
        public string CollectionType { get; set; }

        public Booking()
        {

        }
    }
}
