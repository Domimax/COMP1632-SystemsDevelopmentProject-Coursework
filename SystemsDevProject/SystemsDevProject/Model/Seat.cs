namespace SystemsDevProject
{
    public class Seat
    {
        public int SeatID { get; set; }
        public int SeatNumber { get; set; }
        public bool Occupied { get; set; }

        public Seat()
        {

        }

        public Seat(int seatNumber, bool occupied)
        {
            SeatNumber = seatNumber;
            Occupied = occupied;
        }
    }
}