using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;

namespace RoBot.Actions
{
    public class PlaceAction : BaseAction
    {
        public PlaceAction(Item item, MapDataProvider mapDataProvider, Position position) : base(item, mapDataProvider)
        {
            this.NewPosition = position;
        }

        public Position NewPosition { get; private set; }

        protected override Result Execute()
        {
            throw new NotImplementedException();
        }

        protected override Result ValidateAction()
        {
            if (this.NewPosition == null)
            {
                return new Result(false);
            }

            return base.ValidateAction();
        }
    }
}
