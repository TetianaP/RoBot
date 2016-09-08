using RoBot.Classes;
using System;
using RoBot.Entities;
using RoBot.Classes.MapProviders;

namespace RoBot.Actions
{
    public class MoveAction : BaseAction
    {
        public MoveAction(Robot item, MapDataProvider mapDataProvider) : base(item, mapDataProvider)
        {
        }

        public new Robot Item {
            get { return (Robot)base.Item; }
        }

        protected override Result Execute()
        {
            var step = 1;
            BidimensionalPoint newPosition;
            switch (Item.Direction)
            {
                case Direction.NORTH:
                    newPosition = new BidimensionalPoint(this.Item.Position.Latitude, this.Item.Position.Longitude + step);
                    break;
                case Direction.SOUTH:
                    newPosition = new BidimensionalPoint(this.Item.Position.Latitude, this.Item.Position.Longitude - step);
                    break;
                case Direction.EAST:
                    newPosition = new BidimensionalPoint(this.Item.Position.Latitude + step, this.Item.Position.Longitude);
                    break;
                case Direction.WEST:
                    newPosition = new BidimensionalPoint(this.Item.Position.Latitude - step, this.Item.Position.Longitude);
                    break;
                default:
                    throw new ArgumentException(string.Format("No action move found for '{0}' direction", Item.Direction));
            }

            this.Item.SetPosition(newPosition);
            return new Result(true);
        }

        protected override Result ValidateAction()
        {
            var result = base.ValidateAction();
            if (!result.IsSuccess)
            {
                return result;
            }

            return new Result(Item.Position != null);
        }
    }
}
