using RoBot.Actions;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.ActionFabrics
{
    public abstract class BaseActionCreator
    {
        public abstract BaseAction CreateAction(Item item, MapDataProvider mapDataProvider, string actionParameters);
    }
}
