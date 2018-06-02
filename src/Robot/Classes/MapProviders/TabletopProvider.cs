using Robot.Interfaces;
using Robot.Models;

namespace Robot.Classes.MapProviders
{
    public class TabletopProvider : IMapDataProvider
    {
        private int TableLength { get; }
        private int TableWidth { get; }

        public TabletopProvider(int sideLength)
        {
            TableLength = sideLength;
            TableWidth = sideLength;
        }

        public TabletopProvider(int length, int width)
        {
            TableLength = length;
            TableWidth = width;
        }

        public bool IsPositionAvailable(IPosition position)
        {
            return position.Latitude <= (TableLength - 1) && position.Longitude <= (TableWidth - 1) &&
                position.Latitude >= 0 && position.Longitude >= 0;
        }
    }
}
