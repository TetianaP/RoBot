using RoBot.ActionFabrics;
using RoBot.Actions;
using RoBot.Classes.MapProviders;
using RoBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoBot.Classes
{
    public class ActionManager
    {
        public Item Item { get; private set; }

        public MapDataProvider MapDataProvider { get; private set; }

        private Dictionary<string, BaseActionCreator> ActionsData { get; }

        public ActionManager(Item item, MapDataProvider mapDataProvider)
        {
            this.Item = item;
            this.MapDataProvider = mapDataProvider;
            this.ActionsData = new Dictionary<string, BaseActionCreator>();
        }

        public BaseAction CreateAction(string actionString)
        {
            string[] actionData = actionString.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            var actionName = actionData[0].ToLower();
            var actionParameters = actionData.Length > 1 ? actionData[1] : string.Empty;

            BaseActionCreator creator = this.GetActionCreator(actionName);
            if (creator == null)
            {
                return null;
            }
            
            return creator.CreateAction(this.Item, this.MapDataProvider, actionParameters);
        }

        public void RegisterAction(string actionName, BaseActionCreator creator)
        {
            if (this.GetActionCreator(actionName) != null)
            {
                throw new Exception(string.Format("Action with '{0)' name already exist", actionName));
            }

            this.ActionsData.Add(actionName, creator);
        }

        private BaseActionCreator GetActionCreator(string actionName)
        {
            BaseActionCreator creator;
            this.ActionsData.TryGetValue(actionName, out creator);
            return creator;
        }
    }
}
