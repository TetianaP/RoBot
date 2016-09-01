using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.Actions
{
    public class PlaceAction : BaseAction
    {
        public PlaceAction(Item item, MapDataProvider mapDataProvider, Position position) : base(item, mapDataProvider)
        {
            this.NewPosition = position;
        }

        public Position NewPosition { get; private set; }

        protected override Result Execute()
        {
            this.Item.Position = this.NewPosition;
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
