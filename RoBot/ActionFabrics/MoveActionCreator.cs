using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Actions;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.ActionFabrics
{
    public class MoveActionCreator : BaseActionCreator
    {
        public override BaseAction CreateAction(Item item, MapDataProvider mapDataProvider, string actionParameters)
        {
            return new MoveAction(item, mapDataProvider);
        }
    }
}
