using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    class Ticket
    {

        public double TicketPrice { get; set; }
        public string TicketDescription { get; set; }
        public string TicketType { get; set; }
        public Seat TicketSeat { get; set; }

        public Ticket()
        {

        }

        public Ticket(double ticketPrice, string ticketDescription, string ticketType, Seat ticketSeat)
        {
            TicketPrice = ticketPrice;
            TicketDescription = ticketDescription;
            TicketType = ticketType;
            TicketSeat = ticketSeat;
        }
    }
}
