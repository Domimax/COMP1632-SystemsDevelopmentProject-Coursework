using System.Collections.Generic;

namespace SystemsDevProject
{
    public class Band
    {
        public string BandNumber { get; set; }
        public string BandPrice { get; set; }
        public List<Seat> BandSeats { get; set; }

        public Band()
        {

        }

        public Band(string bandNumber, string bandPrice)
        {
            BandNumber = bandNumber;
            BandPrice = bandPrice;
            BandSeats = new List<Seat>();
        }
    }
}