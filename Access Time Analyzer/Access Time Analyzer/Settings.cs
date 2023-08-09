using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Access_Time_Analyzer
{
    public class Settings
    {
        string settingsFileName = "SqlSettings.txt";
        public string sqlServerName;
        public Settings() 
        {
            getSettings();
        }

        public void getSettings()
        {
            //get settings from file
            if(File.Exists(settingsFileName))
            {
                string[] lines = File.ReadAllLines(settingsFileName);
                sqlServerName = lines[0];
            }
            else
            {
                throw new Exception("Error, settings file not present");
            }
        }

        public void setSettings() 
        { 
            //set settings in file based on current values
            if(sqlServerName != null || sqlServerName != "") 
            {
                File.WriteAllText(settingsFileName, sqlServerName);
            }
            else
            {
                throw new Exception("Server name cannot be blank");
            }
            
        }
    }
}
