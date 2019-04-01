using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    //class to store card details as object
    public class CardDetails
    {
        public int CardDetailsID { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }

        public CardDetails(string nameOnCard, string cardNumber, string cardType, DateTime expirationDate, string cVV)
        {
            NameOnCard = nameOnCard;
            CardNumber = cardNumber;
            CardType = cardType;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }
    }
}
