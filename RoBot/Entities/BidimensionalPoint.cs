using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Classes;

namespace RoBot.Entities
{
    public class BidimensionalPoint : Position
    {
        public BidimensionalPoint(int latitude, int longitude) : base(latitude, longitude)
        {
        }
    }
}
