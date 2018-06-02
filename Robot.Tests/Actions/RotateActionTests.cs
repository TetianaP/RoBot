using Moq;
using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;
using Xunit;

namespace Robot.Tests.Actions
{
    public class RotateActionTests
    {
        private readonly Models.Robot _robot = new Models.Robot
        {
            Direction = Direction.South,
            Position = new BidimensionalPoint(3, 2)
        };
        private readonly IMapDataProvider _mapProvider = new Mock<IMapDataProvider>().Object;

        [Theory]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        public void Run_ShouldUpdateDirection_WhenRotateRight(Direction robotDirection, Direction expectedDirection)
        {
            _robot.Direction = robotDirection;
            var action = new RotateAction(_robot, _mapProvider, RotateDirection.Right);
            action.Run();
            Assert.Equal(expectedDirection, _robot.Direction);
        }


        [Theory]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        public void Run_ShouldUpdateDirection_WhenRotateLeft(Direction robotDirection, Direction expectedDirection)
        {
            _robot.Direction = robotDirection;
            var action = new RotateAction(_robot, _mapProvider, RotateDirection.Left);
            action.Run();
            Assert.Equal(expectedDirection, _robot.Direction);
        }

        [Fact]
        public void Run_ShouldNotChangePosition()
        {
            var action = new RotateAction(_robot, _mapProvider, RotateDirection.Left);
            action.Run();
            Assert.Equal(3, _robot.Position.Latitude);
            Assert.Equal(2, _robot.Position.Longitude);
        }

        [Fact]
        public void Run_ShouldNotThrowException__IfRobotNotPlaced()
        {
            _robot.Position = null;
            var action = new RotateAction(_robot, _mapProvider, RotateDirection.Left);
            action.Run();
        }

        [Fact]
        public void Run_ShouldHandleMultipleActions()
        {
            var action = new RotateAction(_robot, _mapProvider, RotateDirection.Right);
            action.Run();
            action.Run();
            Assert.Equal(Direction.North, _robot.Direction);
        }

        [Fact]
        public void Run_ShouldRotateToSameDirection()
        {
            var action = new RotateAction(_robot, _mapProvider, RotateDirection.Right);
            action.Run();
            action.Run();
            action.Run();
            action.Run();
            Assert.Equal(Direction.South, _robot.Direction);
        }
    }
}