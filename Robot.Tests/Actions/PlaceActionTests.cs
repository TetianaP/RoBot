using Moq;
using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;
using Xunit;

namespace Robot.Tests.Actions
{
    public class PlaceActionTests
    {
        private readonly Models.Robot _robot = new Models.Robot();
        private readonly Mock<IMapDataProvider> _mapProviderMock = new Mock<IMapDataProvider>();


        [Fact]
        public void Run_ShouldSetPositionAndDirection()
        {
            _mapProviderMock.Setup(mapProvider => mapProvider.IsPositionAvailable(It.IsAny<IPosition>())).Returns(true);
            var action = new PlaceAction(_robot, _mapProviderMock.Object, new BidimensionalPoint(2, 1), Direction.North);
            action.Run();

            Assert.Equal(Direction.North, _robot.Direction);;
            Assert.Equal(2, _robot.Position.Latitude);
            Assert.Equal(1, _robot.Position.Longitude);
        }

        [Fact]
        public void Run_ShouldNotSetPositionOrDirection_IfPositionNotValid()
        {
            _mapProviderMock.Setup(mapProvider => mapProvider.IsPositionAvailable(It.IsAny<IPosition>())).Returns(false);
            var action = new PlaceAction(_robot, _mapProviderMock.Object, new BidimensionalPoint(2, 1), Direction.North);
            action.Run();

            Assert.Null(_robot.Position);
            Assert.Equal(Direction.None, _robot.Direction);
        }

        [Fact]
        public void Run_ShouldNotSetPositionOrDirection_IfDirectionNone()
        {
            var action = new PlaceAction(_robot, _mapProviderMock.Object, new BidimensionalPoint(2, 1), Direction.None);
            action.Run();

            Assert.Null(_robot.Position);
            Assert.Equal(Direction.None, _robot.Direction);
        }

        [Fact]
        public void Run_ShouldkeepPreviousPositionOrDirection_IfNotValid()
        {
            var position = new BidimensionalPoint(1, 3);
            _robot.Position = position;
            _robot.Direction = Direction.East;
            _mapProviderMock.Setup(mapProvider => mapProvider.IsPositionAvailable(It.IsAny<IPosition>())).Returns(false);
            var action = new PlaceAction(_robot, _mapProviderMock.Object, new BidimensionalPoint(2, 1), Direction.West);
            action.Run();

            Assert.Equal(position, _robot.Position);
            Assert.Equal(Direction.East, _robot.Direction);
        }
    }
}