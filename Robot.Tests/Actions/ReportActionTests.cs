using Moq;
using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;
using Xunit;

namespace Robot.Tests.Actions
{
    public class ReportActionTests
    {
        private readonly Models.Robot _robot = new Models.Robot
        {
            Direction = Direction.South,
            Position = new BidimensionalPoint(3, 2)
        };
        private readonly IMapDataProvider _mapProvider = new Mock<IMapDataProvider>().Object;
        private readonly Mock<IReporter> _reporterMock = new Mock<IReporter>();

        [Fact]
        public void Run_ShouldShowReport()
        {
            var action = new ReportAction(_robot, _mapProvider, _reporterMock.Object);
            action.Run();
            _reporterMock.Verify(reporter => reporter.Info("Position: 3 2, facing: SOUTH."), Times.Once);
        }

        [Fact]
        public void Run_ShouldNotThrowException__IfRobotNotPlaced()
        {
            _robot.Position = null;
            var action = new ReportAction(_robot, _mapProvider, _reporterMock.Object);
            action.Run();
        }
    }
}