using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;
using System;

namespace Robot.Actions
{
    public class MoveAction : BaseAction
    {
        public MoveAction(IRobot item, IMapDataProvider mapDataProvider): base(item, mapDataProvider)
        {
        }

        protected override Result Execute()
        {
            var step = 1;
            BidimensionalPoint newPosition;
            switch (Item.Direction)
            {
                case Direction.North:
                    newPosition = new BidimensionalPoint(Item.Position.Latitude, Item.Position.Longitude + step);
                    break;
                case Direction.South:
                    newPosition = new BidimensionalPoint(Item.Position.Latitude, Item.Position.Longitude - step);
                    break;
                case Direction.East:
                    newPosition = new BidimensionalPoint(Item.Position.Latitude + step, Item.Position.Longitude);
                    break;
                case Direction.West:
                    newPosition = new BidimensionalPoint(Item.Position.Latitude - step, Item.Position.Longitude);
                    break;
                case Direction.None:
                default:
                    throw new ArgumentException(string.Format("No action move found for '{0}' direction", Item.Direction));
            }

            Item.Position = newPosition;
            return new Result(true);
        }

        protected override bool IsActionValid()
        {
            return base.IsActionValid() && Item.Position != null;
        }
    }
}
