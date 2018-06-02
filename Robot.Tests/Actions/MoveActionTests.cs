using Moq;
using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;
using System;
using Xunit;

namespace Robot.Tests.Actions
{
    public class MoveActionTests
    {
        private readonly Models.Robot _robot = new Models.Robot
        {
            Direction = Direction.South,
            Position = new BidimensionalPoint(3, 2)
        };
        private readonly Mock<IMapDataProvider> _mapProviderMock = new Mock<IMapDataProvider>();

        public MoveActionTests()
        {
            _mapProviderMock.Setup(mapProvider => mapProvider.IsPositionAvailable(It.IsAny<IPosition>())).Returns(true);
        }

        [Theory]
        [InlineData(Direction.South, 3, 1)]
        [InlineData(Direction.West, 2, 2)]
        [InlineData(Direction.North, 3, 3)]
        [InlineData(Direction.East, 4, 2)]
        public void Run_ShouldUpdatePosition(Direction robotDirection, int expectedLatitude, int expectedLongitude)
        {
            _robot.Direction = robotDirection;
            var action = new MoveAction(_robot, _mapProviderMock.Object);
            action.Run();
            Assert.Equal(expectedLatitude, _robot.Position.Latitude);
            Assert.Equal(expectedLongitude, _robot.Position.Longitude);
        }

        [Fact]
        public void Run_ShouldNotChangeDirection()
        {
            var action = new MoveAction(_robot, _mapProviderMock.Object);
            action.Run();
            Assert.Equal(Direction.South, _robot.Direction);
        }

        [Fact]
        public void Run_ShouldKeepPreviousPosition_IfNotValid()
        {
            _mapProviderMock.Setup(mapProvider => mapProvider.IsPositionAvailable(It.IsAny<IPosition>())).Returns(false);
            var action = new MoveAction(_robot, _mapProviderMock.Object);
            action.Run();
            Assert.Equal(3, _robot.Position.Latitude);
            Assert.Equal(2, _robot.Position.Longitude);
        }

        [Fact]
        public void Run_ShouldThrowException_IfRobotDirectionNone()
        {
            _robot.Direction = Direction.None;
            var action = new MoveAction(_robot, _mapProviderMock.Object);
            Assert.Throws<ArgumentException>(() => action.Run());
        }

        [Fact]
        public void Run_ShouldNotThrowException__IfRobotNotPlaced()
        {
            _robot.Position = null;
            var action = new MoveAction(_robot, _mapProviderMock.Object);
            action.Run();
        }
    }
}