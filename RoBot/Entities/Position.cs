using RoBot.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Entities
{
    public abstract class Position
    {
        public Position(int latitude, int longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// X-axis coordinate
        /// </summary>
        public int Latitude { get; private set; }

        /// <summary>
        /// Y-axis coordinate
        /// </summary>
        public int Longitude { get; private set; }
    }
}
