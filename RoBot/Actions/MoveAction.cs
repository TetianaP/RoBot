using RoBot.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Entities;
using RoBot.Classes.MapProviders;

namespace RoBot.Actions
{
    public class MoveAction : BaseAction
    {
        public MoveAction(Item item, MapDataProvider mapDataProvider) : base(item, mapDataProvider)
        {
        }

        protected override Result Execute()
        {
            throw new NotImplementedException();
        }
    }
}
