using RoBot.Actions;
using RoBot.Classes.MapProviders;
using RoBot.Entities;
using RoBot.Classes;

namespace RoBot.ActionFabrics
{
    public class RotateLeftActionCreator : BaseActionCreator
    {
        public override BaseAction CreateAction(Item item, MapDataProvider mapDataProvider, string actionParameters)
        {
            return new RotateAction(item as Robot, mapDataProvider, RotateDirection.Left);
        }
    }
}
