using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace AccessTimeAnalyzerWPF
{
    public  class Update
    {

        //Begin logging info
        string logFile = "log.txt";
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        //End logging info


        /// <summary>
        /// This class contains functions and variables for checking if the application version is older than the version available on github
        /// </summary>
        public Update() 
        {
            ///// <summary>
            ///// Function to standardize logging data format.
            //// Currently not functioning in this class. NBM 8/10/2023
            ///// </summary>
            ///// <param name="logData"></param>
            //void log(string logData)
            //{
            //    File.AppendAllTextAsync(logFile, "[" + DateTime.Now + "] " + "[User name: " + userName + "] Log: " + logData + "\n");
            //}


            try
            {
                ///getting version on github
                System.Net.WebClient wc = new System.Net.WebClient();
                string webData = wc.DownloadString("https://raw.githubusercontent.com/NoahMoyer/AccessTimeAnalyzerPublic/main/Access%20Time%20Analyzer/Access%20Time%20Analyzer/Properties/AssemblyInfo.cs");

                //parse webData for the following line:
                //[assembly: AssemblyVersion("1.2.2")]
                var versionLineRegex = Regex.Match(webData, @"AssemblyVersion\s*\(\s*""([0-9\.]*?)""\s*\)");
                string versionLineString = versionLineRegex.ToString();
                string[] versionArray = versionLineString.Split('\"');
                //string onlineVersion should be the following using the previous example:
                //1.2.2
                int[] onlineVersion = versionArray[1].Split('.').Select(n => Convert.ToInt32(n)).ToArray(); ;

                ///getting version from local system
                //This function is similar to the above. Only difference is we don't have to parse the file.
                //localVersionVar is simply returning the version number reported by the assembler
                var localVersionVar = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string localVersionString = localVersionVar.ToString();
                int[] localVersion = localVersionString.Split('.').Select(n => Convert.ToInt32(n)).ToArray();

                //compare version numbers
                for (int i = 0; onlineVersion.Length > i; i++)
                {
                    //if version on github is greater than the local version return true
                    if (onlineVersion[i] > localVersion[i])
                    {
                        updateAvail = true;
                    }
                }
            }
            catch
            {
                //Need to enable logging function once this is fixed.
                //log("Unhandeled exception occured. Cath error:\n " + Error);
            }



        }

        public bool updateAvail { get; set; }
    }
}
