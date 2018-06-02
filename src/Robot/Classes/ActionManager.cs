using Robot.ActionFactories;
using Robot.Interfaces;
using System;
using System.Collections.Generic;

namespace Robot.Classes
{
    public class ActionManager
    {
        public IRobot Item { get; }

        public IMapDataProvider MapDataProvider { get; }

        private Dictionary<string, BaseActionCreator> ActionsData { get; }

        public ActionManager(IRobot item, IMapDataProvider mapDataProvider)
        {
            Item = item;
            MapDataProvider = mapDataProvider;
            ActionsData = new Dictionary<string, BaseActionCreator>();
        }

        public IAction CreateAction(string actionString)
        {
            string[] actionData = actionString.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            var actionName = actionData[0].ToLower();
            var actionParameters = actionData.Length > 1 ? actionData[1] : string.Empty;

            BaseActionCreator creator = this.GetActionCreator(actionName);

            return creator?.CreateAction(Item, MapDataProvider, actionParameters);
        }

        public void RegisterAction(string actionName, BaseActionCreator creator)
        {
            if (GetActionCreator(actionName) != null)
            {
                throw new Exception(string.Format("Action with '{0)' name already exist", actionName));
            }

            ActionsData.Add(actionName, creator);
        }

        private BaseActionCreator GetActionCreator(string actionName)
        {
            ActionsData.TryGetValue(actionName, out var creator);
            return creator;
        }
    }
}
