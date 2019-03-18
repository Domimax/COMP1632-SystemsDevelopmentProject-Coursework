using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    //class to store card details as object
    class CardDetails
    {
        public string cardnumber { get; set; }

        public string tickepurchase { get; set; }

        public string cardtype { get; set; }
        public string MM { get; set; }
        public string YY { get; set; }
        public string CVV { get; set; }

        public CardDetails(string tp, string cn, string ct, string mm, string yy, string cvv)
        {
            tickepurchase = tp;
            cardnumber = cn;
            cardtype = ct;
            MM = mm;
            YY = yy;
            CVV = cvv;

        }
    }
}
