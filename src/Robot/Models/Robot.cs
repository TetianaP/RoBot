using Robot.Classes;
using Robot.Interfaces;

namespace Robot.Models
{
    public class Robot : IRobot
    {
        private IPosition _position;

        public Direction Direction { get; set; } = Direction.None;

        public PositionValidator OnPositionChange { get; set; }

        public IPosition Position
        {
            get => _position;
            set
            {
                if (OnPositionChange != null && !OnPositionChange(value))
                {
                    return;
                }

                _position = value;
            }
        }
    }
}
