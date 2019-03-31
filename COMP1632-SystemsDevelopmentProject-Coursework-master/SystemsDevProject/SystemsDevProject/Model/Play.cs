using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject
{
    public class Play
    {
        public string PlayName { get; set; }
        public int PlayDuration { get; set; }
        public string PlayCast { get; set; }
        public string PictureString { get; set; }

        public List<Review> PlayReviews { get; set; }
        public List<Performance> PlayPerformances { get; set; }

        public Play()
        {

        }

        public Play(string playName, int playDuration)
        {
            PlayName = playName;
            PlayDuration = playDuration;
            PlayReviews = new List<Review>();
            PlayPerformances = new List<Performance>();
        }
    }
}
