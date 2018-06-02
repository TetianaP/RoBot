using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;

namespace Robot.Actions
{
    public class PlaceAction : BaseAction
    {
        private readonly IPosition _newPosition;

        private readonly Direction _newDirection;

        public PlaceAction(IRobot item, IMapDataProvider mapDataProvider, IPosition position, Direction direction) : base(item, mapDataProvider)
        {
            _newPosition = position;
            _newDirection = direction;
        }

        protected override Result Execute()
        {
            if (IsPositionValid(_newPosition) && _newDirection != Direction.None)
            {
                Item.Position = _newPosition;
                Item.Direction = _newDirection;
            }

            return new Result(true);
        }
    }
}
