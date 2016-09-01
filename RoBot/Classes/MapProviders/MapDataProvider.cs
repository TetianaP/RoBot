using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Entities;

namespace RoBot.Classes.MapProviders
{
    /// <summary>
    /// Represents a surface provider for interaction. Should be widen with exact map that could be changed
    /// </summary>
    public abstract class MapDataProvider
    {
        


        public virtual bool IsPositionAvailable(Position position)
        {
            return true;
        }
    }
}
