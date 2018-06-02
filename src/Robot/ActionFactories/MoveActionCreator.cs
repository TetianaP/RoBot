using Robot.Actions;
using Robot.Interfaces;

namespace Robot.ActionFactories
{
    public class MoveActionCreator : BaseActionCreator
    {
        public override IAction CreateAction(IRobot item, IMapDataProvider mapDataProvider, string actionParameters)
        {
            return new MoveAction(item, mapDataProvider);
        }
    }
}
