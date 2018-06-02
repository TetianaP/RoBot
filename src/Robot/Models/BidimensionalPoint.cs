namespace Robot.Models
{
    public class BidimensionalPoint : IPosition
    {
        /// <summary>
        /// X-axis coordinate
        /// </summary>
        public int Latitude { get; }

        /// <summary>
        /// Y-axis coordinate
        /// </summary>
        public int Longitude { get; }

        public BidimensionalPoint(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
