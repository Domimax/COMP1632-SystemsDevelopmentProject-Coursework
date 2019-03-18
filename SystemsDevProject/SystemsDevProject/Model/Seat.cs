namespace SystemsDevProject
{
    public class Seat
    {
        public string SeatNumber { get; set; }
        public bool Occupied { get; set; }

        public Seat()
        {

        }

        public Seat(string seatNumber, bool occupied)
        {
            SeatNumber = seatNumber;
            Occupied = occupied;
        }
    }
}