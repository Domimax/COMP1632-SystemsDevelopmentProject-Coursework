using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }

        public Review()
        {

        }

        public Review(string reviewText, DateTime reviewDate)
        {
            ReviewText = reviewText;
            ReviewDate = reviewDate;
        }
    }
}
