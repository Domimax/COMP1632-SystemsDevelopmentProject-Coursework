namespace SystemsDevProject
{
    public class Band
    {
        public string BandNumber { get; set; }
        public string BandPrice { get; set; }

        public Band()
        {

        }

        public Band(string bandNumber, string bandPrice)
        {
            BandNumber = bandNumber;
            BandPrice = bandPrice;
        }
    }
}