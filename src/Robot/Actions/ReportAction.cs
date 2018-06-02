using Robot.Classes;
using Robot.Interfaces;

namespace Robot.Actions
{
    public class ReportAction : BaseAction
    {
        private readonly IReporter _reporter;

        public ReportAction(IRobot item, IMapDataProvider mapDataProvider, IReporter reporter) : base(item, mapDataProvider)
        {
            _reporter = reporter;
        }

        protected override Result Execute()
        {
            _reporter.Info($"Position: {Item.Position.Latitude} {Item.Position.Longitude}, facing: {Item.Direction.ToString().ToUpper()}.");
            return new Result(true);
        }

        protected override bool IsActionValid()
        {
            return base.IsActionValid() && Item.Position != null;
        }
    }
}
