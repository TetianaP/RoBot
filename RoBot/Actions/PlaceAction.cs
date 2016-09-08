using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.Actions
{
    public class PlaceAction : BaseAction
    {
        public PlaceAction(Robot item, MapDataProvider mapDataProvider, BidimensionalPoint position, Direction direction) : base(item, mapDataProvider)
        {
            this.NewPosition = position;
            this.NewDirection = direction;
        }

        public BidimensionalPoint NewPosition { get; private set; }
        public Direction NewDirection { get; private set; }

        public new Robot Item
        {
            get { return (Robot)base.Item; }
        }

        protected override Result Execute()
        {
            this.Item.SetPosition(this.NewPosition);
            return new Result(true);
        }

        protected override Result ValidateAction()
        {
            var result = base.ValidateAction();
            if (!result.IsSuccess)
            {
                return result;
            }

            return new Result(this.NewPosition != null);
        }
    }
}
