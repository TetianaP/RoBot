using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Entities;

namespace RoBot.Classes.MapProviders
{
    public class TabletopProvider : MapDataProvider
    {
        public TabletopProvider(int sideLength)
        {
            this.TableLength = sideLength;
            this.TableWidth = sideLength;
        }

        public TabletopProvider(int length, int width)
        {
            this.TableLength = length;
            this.TableWidth = width;
        }

        public int TableLength { get; private set; }
        public int TableWidth { get; private set; }

        public override bool IsPositionAvailable(Position position)
        {
            return position.Latitude <= (this.TableLength - 1) && position.Longitude <= (this.TableWidth - 1) &&
                position.Latitude >= 0 && position.Longitude >= 0;
        }
    }
}
