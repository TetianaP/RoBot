using RoBot.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Entities
{
    public class Position
    {
        public Position(int latitude, int longitude, Direction direction)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Direction = direction;
        }

        /// <summary>
        /// X-axis coordinate
        /// </summary>
        public int Latitude { get; set; }

        /// <summary>
        /// Y-axis coordinate
        /// </summary>
        public int Longitude { get; set; }

        /// <summary>
        /// Direction of cource
        /// </summary>
        public Direction Direction { get; set; }
    }
}
