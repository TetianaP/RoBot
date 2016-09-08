using System;
using RoBot.Entities;
using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.ActionFabrics;

namespace RoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Item robot = new Robot();
            MapDataProvider squareTabletopProvider = new TabletopProvider(5);
            var actionManager = new ActionManager(robot, squareTabletopProvider);

            // Register all actions available, should be moved to core or configuration
            actionManager.RegisterAction("move", new MoveActionCreator());
            actionManager.RegisterAction("place", new PlaceActionCreator());
            actionManager.RegisterAction("left", new RotateLeftActionCreator());
            actionManager.RegisterAction("right", new RotateRightActionCreator());
            actionManager.RegisterAction("report", new ReportActionCreator());

            while (true)
            {
                var actionData = Console.ReadLine();
                var action = actionManager.CreateAction(actionData);
                if (action == null)
                {
                    Console.WriteLine("Can not find an action");
                }
                
                action.Run();
            }
        }
    }
}
