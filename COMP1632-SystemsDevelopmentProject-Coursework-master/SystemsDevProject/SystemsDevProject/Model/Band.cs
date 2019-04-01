using System.Collections.Generic;

namespace SystemsDevProject
{
    public class Band
    {
        public int BandID { get; set; }
        public string BandNumber { get; set; }
        public double BandPrice { get; set; }
        public List<Seat> BandSeats { get; set; }

        public Band()
        {

        }

        public Band(string bandNumber, double bandPrice)
        {
            BandNumber = bandNumber;
            BandPrice = bandPrice;
            BandSeats = new List<Seat>();
        }
    }
}