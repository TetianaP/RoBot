using Robot.Actions;
using Robot.Classes;
using Robot.Interfaces;

namespace Robot.ActionFactories
{
    public class ReportActionCreator : BaseActionCreator
    {
        public override IAction CreateAction(IRobot item, IMapDataProvider mapDataProvider, string actionParameters)
        {
            return new ReportAction(item, mapDataProvider, new OutputReporter());
        }
    }
}
