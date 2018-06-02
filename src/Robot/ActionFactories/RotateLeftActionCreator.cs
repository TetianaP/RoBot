using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;

namespace Robot.ActionFactories
{
    public class RotateLeftActionCreator : BaseActionCreator
    {
        public override IAction CreateAction(IRobot item, IMapDataProvider mapDataProvider, string actionParameters)
        {
            return new RotateAction(item, mapDataProvider, RotateDirection.Left);
        }
    }
}
