using Robot.Classes;
using Robot.Models;

namespace Robot.Interfaces
{
    public delegate bool PositionValidator(IPosition position);

    public interface IRobot
    {
        /// <summary>
        /// Direction the robot is facing
        /// </summary>
        Direction Direction { get; set; }

        /// <summary>
        /// Direction the robot is facing
        /// </summary>
        IPosition Position { get; set; }

        PositionValidator OnPositionChange { get; set; }
    }
}
