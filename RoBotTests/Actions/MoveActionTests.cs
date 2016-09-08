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
    public class MoveActionTests
    {
        [TestMethod()]
        public void MoveActionTest()
        {
            var point = new BidimensionalPoint(3, 2);
            var robot = new Robot() { Direction = Direction.SOUTH };
            robot.SetPosition(point);
            var squareTabletopProvider = new TabletopProvider(5);

            var action = new MoveAction(robot, squareTabletopProvider);
            action.Run();
            Assert.AreEqual<Direction>(Direction.SOUTH, robot.Direction);
            var position = robot.GetPosition();
            Assert.AreEqual(position.Latitude, 3);
            Assert.AreEqual(position.Longitude, 1);

            action.Run();
            Assert.AreEqual<Direction>(Direction.SOUTH, robot.Direction);
            position = robot.GetPosition();
            Assert.AreEqual(position.Latitude, 3);
            Assert.AreEqual(position.Longitude, 0);

            action.Run();
            Assert.AreEqual<Direction>(Direction.SOUTH, robot.Direction);
            position = robot.GetPosition();
            Assert.AreEqual(position.Latitude, 3);
            Assert.AreEqual(position.Longitude, 0);
        }
    }
}