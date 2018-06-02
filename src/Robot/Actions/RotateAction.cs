using Robot.Classes;
using Robot.Interfaces;
using System;

namespace Robot.Actions
{
    public class RotateAction : BaseAction
    {
        private RotateDirection RotateDirection { get; }

        public RotateAction(IRobot item, IMapDataProvider mapDataProvider, RotateDirection rotateDirection) : base(item, mapDataProvider)
        {
            RotateDirection = rotateDirection;
        }

        protected override Result Execute()
        {
            int step;
            var directionsNumber = 4;
            switch (RotateDirection)
            {
                case RotateDirection.Left:
                    step = -1;
                    break;
                case RotateDirection.Right:
                    step = 1;
                    break;
                default:
                    throw new ArgumentException($"No action rotate found for '{RotateDirection}' direction");
            }

            var absNone = (Math.Abs(step / directionsNumber) + 1) * directionsNumber;
            var direction = ((int)Item.Direction + step + absNone) % directionsNumber;
            Item.Direction = (Direction)direction;

            return new Result(true);
        }

        protected override bool IsActionValid()
        {
            return base.IsActionValid() && Item.Position != null;
        }
    }
}
