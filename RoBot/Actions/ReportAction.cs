using System;
using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.Actions
{
    public class ReportAction : BaseAction
    {
        public ReportAction(Item item, MapDataProvider mapDataProvider) : base(item, mapDataProvider)
        {
        }

        protected override Result Execute()
        {
            if (Item.Position == null)
            {
                throw new Exception("Position is not set for current item");
            }

            Console.WriteLine(string.Format("Position: {0} {1}, facing: {2}.", this.Item.Position.Latitude, this.Item.Position.Longitude, this.Item.Position.Direction.ToString().ToUpper()));
            return new Result(true);
        }
    }
}
