namespace SystemsDevProject
{
    public class Seat
    {
        public Band SeatBand { get; set; }
        public string SeatNumber { get; set; }

        public Seat()
        {

        }

        public Seat(Band seatBand, string seatNumber)
        {
            SeatBand = seatBand;
            SeatNumber = seatNumber;
        }
    }
}