namespace Robot.Models
{
    public interface IPosition
    {
        /// <summary>
        /// X-axis coordinate
        /// </summary>
        int Latitude { get; }

        /// <summary>
        /// Y-axis coordinate
        /// </summary>
        int Longitude { get; }
    }
}
