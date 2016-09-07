using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoBot.Actions;
using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Actions.Tests
{
    [TestClass()]
    public class PlaceActionTests
    {
        [TestMethod()]
        public void PlaceActionTest()
        {
            var robot = new Robot();
            var squareTabletopProvider = new SquareTabletopProvider(5);

            var point = new BidimensionalPoint(3, 4);
            var action = new PlaceAction(robot, squareTabletopProvider, point, Direction.NORTH);
            action.Run();
            Assert.AreEqual<Direction>(Direction.NORTH, robot.Direction);
            var position = robot.GetPosition();
            Assert.AreEqual(position.Latitude, point.Latitude);
            Assert.AreEqual(position.Longitude, point.Longitude);

        }
    }
}