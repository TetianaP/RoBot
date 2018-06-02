using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;

namespace Robot.ActionFactories
{
    public class RotateRightActionCreator : BaseActionCreator
    {
        public override IAction CreateAction(IRobot item, IMapDataProvider mapDataProvider, string actionParameters)
        {
            return new RotateAction(item, mapDataProvider, RotateDirection.Right);
        }
    }
}
