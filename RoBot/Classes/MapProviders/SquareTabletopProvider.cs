using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Entities;

namespace RoBot.Classes.MapProviders
{
    public class SquareTabletopProvider : MapDataProvider
    {
        public SquareTabletopProvider(int squareSide)
        {
            this.SquareSide = squareSide;
        }

        public int SquareSide { get; private set; }

        public override bool IsPositionAvailable(Position position)
        {
            return position.Latitude < (this.SquareSide - 1) && position.Longitude < (this.SquareSide - 1);
        }
    }
}
