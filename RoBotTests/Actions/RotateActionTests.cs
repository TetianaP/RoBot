using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.Actions.Tests
{
    [TestClass()]
    public class RotateActionTests
    {
        [TestMethod()]
        public void RotateActionTest()
        {
            var point = new BidimensionalPoint(3, 4);
            var robot = new Robot() { Direction = Direction.SOUTH };
            robot.SetPosition(point);
            var squareTabletopProvider = new TabletopProvider(5);

            var action = new RotateAction(robot, squareTabletopProvider, RotateDirection.Right);
            action.Run();
            Assert.AreEqual<Direction>(Direction.WEST, robot.Direction);
            Assert.AreEqual<BidimensionalPoint>(robot.GetPosition(), point);

            action = new RotateAction(robot, squareTabletopProvider, RotateDirection.Left);
            action.Run();
            action.Run();
            Assert.AreEqual<Direction>(Direction.EAST, robot.Direction);
            Assert.AreEqual<BidimensionalPoint>(robot.GetPosition(), point);
        }
    }
}