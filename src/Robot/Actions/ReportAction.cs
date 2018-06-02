using Robot.Classes;
using Robot.Interfaces;
using System;

namespace Robot.Actions
{
    public class ReportAction : BaseAction
    {
        public ReportAction(IRobot item, IMapDataProvider mapDataProvider) : base(item, mapDataProvider)
        {
        }

        protected override Result Execute()
        {
            if (Item.Position == null)
            {
                throw new Exception("Position is not set for current item");
            }

            Console.WriteLine("Position: {0} {1}, facing: {2}.", Item.Position.Latitude, Item.Position.Longitude, Item.Direction.ToString().ToUpper());

            return new Result(true);
        }
    }
}
