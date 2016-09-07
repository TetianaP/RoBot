using RoBot.Actions;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.ActionFabrics
{
    public class MoveActionCreator : BaseActionCreator
    {
        public override BaseAction CreateAction(Item item, MapDataProvider mapDataProvider, string actionParameters)
        {
            return new MoveAction(item as Robot, mapDataProvider);
        }
    }
}
