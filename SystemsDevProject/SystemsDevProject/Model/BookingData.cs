using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    class BookingData
    {
        //class to hold booking data as object
        private int seatnumber { get; set; }
        private string category { get; set; }
        private string availability { get; set; }

        public BookingData(int sn, string categ, string av)
        {
            seatnumber = sn;
            category = categ;
            availability = av;
        }

        public int getseatnumber()
        {
            return seatnumber;
        }
        public string getcategory()
        {
            return category;
        }
        public string getavail()
        {
            return availability;
        }
        //get seat alphabet + number
        public string SeatNumber()
        {
            return category + seatnumber.ToString();
        }
    }
}
