using Robot.Interfaces;

namespace Robot.ActionFactories
{
    public abstract class BaseActionCreator
    {
        public abstract IAction CreateAction(IRobot item, IMapDataProvider mapDataProvider, string actionParameters);
    }
}
