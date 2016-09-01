using RoBot.Classes;
using System;
using RoBot.Entities;
using RoBot.Classes.MapProviders;

namespace RoBot.Actions
{
    public class MoveAction : BaseAction
    {
        public MoveAction(Item item, MapDataProvider mapDataProvider) : base(item, mapDataProvider)
        {
        }

        protected override Result Execute()
        {
            var step = 1;
            Position newPosition;
            switch (Item.Position.Direction)
            {
                case Direction.NORTH:
                    newPosition = new Position(this.Item.Position.Latitude, this.Item.Position.Longitude + step, this.Item.Position.Direction);
                    break;
                case Direction.SOUTH:
                    newPosition = new Position(this.Item.Position.Latitude, this.Item.Position.Longitude - step, this.Item.Position.Direction);
                    break;
                case Direction.EAST:
                    newPosition = new Position(this.Item.Position.Latitude + step, this.Item.Position.Longitude, this.Item.Position.Direction);
                    break;
                case Direction.WEST:
                    newPosition = new Position(this.Item.Position.Latitude - step, this.Item.Position.Longitude, this.Item.Position.Direction);
                    break;
                default:
                    throw new ArgumentException(string.Format("No action move found for '{0}' direction", Item.Position.Direction));
            }

            this.Item.Position = newPosition;
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
