using RoBot.Classes;
using RoBot.Classes.MapProviders;
using RoBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Actions
{
    public abstract class BaseAction
    {
        public Item Item { get; private set; }

        public MapDataProvider MapDataProvider { get; private set; }
        
        /// <summary>
        /// Constructor for <see cref="BaseAction"/>
        /// </summary>
        /// <param name="item">item to do action on</param>
        /// <param name="mapDataProvider">map to do action on</param>
        public BaseAction(Item item, MapDataProvider mapDataProvider)
        {
            this.Item = item;
            this.MapDataProvider = mapDataProvider;
            this.Item.OnPositionChange = this.ValidatePosition;
        }

        public Result Run()
        {
            var validateResult = this.ValidateAction();
            if (!validateResult.IsSuccess)
            {
                return validateResult;
            }

            return this.Execute();
        }

        protected abstract Result Execute();

        protected virtual Result ValidateAction()
        {
            return new Result(this.MapDataProvider != null && this.Item != null);
        }

        private Result ValidatePosition(Position position)
        {
            return new Result(MapDataProvider.IsPositionAvailable(position));
        }

    }
}
