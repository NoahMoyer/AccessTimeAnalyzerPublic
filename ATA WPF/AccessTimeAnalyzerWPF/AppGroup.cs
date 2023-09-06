using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessTimeAnalyzerWPF
{
    public class AppGroup
    {
        public AppGroup(string newGroupName, List<defaultApp> listOfDefaultApps)
        {
            groupName = newGroupName;
            defaultApps = listOfDefaultApps;
        }
        public AppGroup(string newGroupName)
        {
            groupName = newGroupName;
        }
        public void addApp(defaultApp appToAdd)
        {
            defaultApps.Add(appToAdd);
        }
        public void removeApp(defaultApp appToRemove)
        {
            if (defaultApps.Contains(appToRemove))
            {
                defaultApps.Remove(appToRemove);
            }
        }
        public string getGroupName()
        {
            return groupName;
        }
        public void setGroupName(string newGroupName)
        {
            groupName = newGroupName;
        }
        public List<defaultApp> getAppsList()
        {
            return defaultApps;
        }
        private string groupName;
        public List<defaultApp> defaultApps = new List<defaultApp>();
    }
}
