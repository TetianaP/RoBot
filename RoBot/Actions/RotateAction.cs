using System;
using RoBot.Classes.MapProviders;
using RoBot.Entities;
using RoBot.Classes;

namespace RoBot.Actions
{
    public class RotateAction : BaseAction
    {
        public RotateAction(Robot item, MapDataProvider mapDataProvider, RotateDirection rotateDirection) : base(item, mapDataProvider)
        {
            this.RotateDirection = rotateDirection;
        }

        public RotateDirection RotateDirection { get; private set; }

        public new Robot Item
        {
            get { return (Robot)base.Item; }
        }

        protected override Result Execute()
        {
            int step;
            int directionsNumber = 4;
            switch (this.RotateDirection)
            {
                case RotateDirection.Left:
                    step = -1;
                    break;
                case RotateDirection.Right:
                    step = 1;
                    break;
                default:
                    throw new ArgumentException(string.Format("No action rotate found for '{0}' direction", this.RotateDirection));
            }

            int absNone = (Math.Abs(step / directionsNumber) + 1) * directionsNumber;
            int direction = ((int)this.Item.Direction + step + absNone) % directionsNumber;
            this.Item.Direction = (Direction)direction;

            return new Result(true);
        }

        protected override Result ValidateAction()
        {
            var result = base.ValidateAction();
            if (!result.IsSuccess)
            {
                return result;
            }

            return new Result(this.RotateDirection != null && this.Item.Position != null);
        }
    }
}
