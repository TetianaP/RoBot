using Robot.Actions;
using Robot.Classes;
using Robot.Helpers;
using Robot.Interfaces;
using System.Linq;
using Robot.Models;

namespace Robot.ActionFactories
{
    public class PlaceActionCreator : BaseActionCreator
    {
        public override IAction CreateAction(IRobot item, IMapDataProvider mapDataProvider, string actionParameters)
        {
            var parameters = actionParameters.Split(',');
            parameters.ToList().ForEach(p => p.Trim());
            if (parameters.Length != 3)
            {
                return null;
            }

            int latitude;
            if (!int.TryParse(parameters[0], out latitude))
            {
                return null;
            }

            int longitude;
            if (!int.TryParse(parameters[1], out longitude))
            {
                return null;
            }

            Direction? direction = parameters[2].ToEnum<Direction>();
            if (direction == null)
            {
                return null;
            }
            
            var position = new BidimensionalPoint(latitude, longitude);
            return new PlaceAction(item, mapDataProvider, position, (Direction)direction);
        }
    }
}
