using RoBot.Actions;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.ActionFabrics
{
    public class ReportActionCreator : BaseActionCreator
    {
        public override BaseAction CreateAction(Item item, MapDataProvider mapDataProvider, string actionParameters)
        {
            return new ReportAction(item, mapDataProvider);
        }
    }
}
