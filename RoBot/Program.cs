using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Entities;
using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Actions;
using RoBot.ActionFabrics;

namespace RoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Item robot = new Robot();
            MapDataProvider squareTabletopProvider = new SquareTabletopProvider(5);
            var actionManager = new ActionManager(robot, squareTabletopProvider);

            // Register all actions available, should be moved to core or configuration
            actionManager.RegisterAction("move", new MoveActionCreator());
            actionManager.RegisterAction("place", new PlaceActionCreator());

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
