using Robot.ActionFactories;
using Robot.Classes;
using Robot.Classes.MapProviders;
using Robot.Interfaces;
using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Models.Robot();
            IMapDataProvider squareTabletopProvider = new TabletopProvider(5);
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
                    continue;
                }

                action.Run();
            }
        }
    }
}
