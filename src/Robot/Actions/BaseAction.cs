using Robot.Classes;
using Robot.Interfaces;
using Robot.Models;

namespace Robot.Actions
{
    public abstract class BaseAction : IAction
    {
        protected IRobot Item { get; }

        private IMapDataProvider MapDataProvider { get; }
        
        /// <summary>
        /// Constructor for <see cref="BaseAction"/>
        /// </summary>
        /// <param name="item">item to do action on</param>
        /// <param name="mapDataProvider">map to do action on</param>
        protected BaseAction(IRobot item, IMapDataProvider mapDataProvider)
        {
            Item = item;
            MapDataProvider = mapDataProvider;
            item.OnPositionChange = IsPositionValid;
        }

        public Result Run()
        {
            if (!IsActionValid())
            {
                return new Result(false);
            }

            return Execute();
        }

        protected abstract Result Execute();

        protected virtual bool IsActionValid()
        {
            return Item != null && MapDataProvider != null;
        }

        protected bool IsPositionValid(IPosition position)
        {
            return MapDataProvider.IsPositionAvailable(position);
        }
    }
}
