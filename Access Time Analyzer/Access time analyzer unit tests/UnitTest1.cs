using Access_Time_Analyzer;
using Microsoft.VisualBasic.FileIO;

namespace Access_time_analyzer_unit_tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "C:\\Program Files (x86)\\Adobe\\Acrobat DC\\Acrobat\\Acrobat.exe";
        CSVeditor testEditor = new CSVeditor();
        private const string reportName = "testReport.csv";
        
        bool BoolResult;
        
        //Here the values will be equal and we expect the function to evaluate that correctly
        [TestMethod]
        public void TestMethod1()
        {
           const bool ExpectedBoolResult = true;
        List<defaultApp> defaultApps = new List<defaultApp>()
        {
            new defaultApp("Acrobat DC", @"C:\Program Files (x86)\Adobe\Acrobat DC\Acrobat\Acrobat.exe"),
            //new defaultApp("Bluebeam", @"C:\Program Files\Bluebeam Software\Bluebeam Revu\20\Revu\Revu32.exe"),
            //new defaultApp("BSA Assessing", @"C:\Program Files (x86)\BS&A Software\Assessing\Assessing.exe"),
            //new defaultApp("BSA Delinquent", @"C:\Program Files (x86)\BS&A Software\Delinquent Personal Property\DlqPersonalProperty.exe"),
            //new defaultApp("BSA Preaudit", @"C:\Program Files (x86)\BS&A Software\PREA\PreAudit.exe"),
            //new defaultApp("BSA Special Assessment", @"C:\Program Files (x86)\BS&A Software\Special Assessment\SpecialAssessments.exe"),
            //new defaultApp("BSA Tax", @"C:\Program Files (x86)\BS&A Software\Tax\Tax.exe"),
            //new defaultApp("Explorer", @"C:\Windows\explorer.exe"),
            //new defaultApp("Legistar", @"C:\Granicus\Legistar5.exe"),
            //new defaultApp("MiCollab", @"C:\Program Files (x86)\Mitel\MiCollab\MiCollab.exe"),
            //new defaultApp("Microsoft Project", @"C:\Program Files\Microsoft Office\root\Office16\WINPROJ.exe"),
            //new defaultApp("Microsoft Publisher", @"C:\Program Files\Microsoft Office\root\Office16\MSPUB.exe"),
            //new defaultApp("Microsoft Visio", @"C:\Program Files\Microsoft Office\root\Office16\VISIO.exe"),
            //new defaultApp("Ocularis", @"C:\Program Files\Qognify\Ocularis Client\OcularisClient.exe"),
            //new defaultApp("Onbase", @"C:\Program Files (x86)\Hyland\Unity Client\obunity.exe"),
            //new defaultApp("Trakit", @"C:\CRW\Application\TrakitClient.exe"),
            //new defaultApp("Trakit", @"C:\CRW\TrakitStart.exe"),
            //new defaultApp("1Password", @"C:\Users\npmoyer\AppData\Local\1Password\app\8\1Password.exe"),
        };
            using (TextFieldParser csvParser = new TextFieldParser(reportName))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    //read line and add each field to a entry in the array
                    string[] fields = csvParser.ReadFields();

                    //check first field to see if the prefetch file is in the defaultApps list
                    //if it is get the fields with the run count and last run dates/times
                    //index 0 = prefetch file name
                    //index 5 = exe location
                    //index 6 = Run count field 
                    //index 7 = last run dates/times
                    //This we want to change to check the app based on the app location instead of prefetch file and get the prefetch file name.
                    foreach (defaultApp app in defaultApps)
                    {
                        
                        if (StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase))
                        {
                            app.prefetchName = fields[0];
                            app.runCount = fields[6];
                            app.lastRunTime = fields[7];
                            Assert.IsTrue(StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase));
                            BoolResult = true;
                        }
                        else
                        {
                            Assert.IsFalse(StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase));
                            BoolResult = false;
                        }
                        Assert.AreEqual(ExpectedBoolResult, BoolResult);
                        
                    }

                }
            }


        }

        //This test method the values won't be equal and we expect the function to evaluate that correctly
        [TestMethod]
        public void TestMethod2()
        {
            const bool ExpectedBoolResult = false;
            List<defaultApp> defaultApps = new List<defaultApp>()
        {
            new defaultApp("Acrobat DC", @"C:\Program Files (x86)\Adobee\Acrobatt DC\Acrobat\Acrobat.exe"),
            //new defaultApp("Bluebeam", @"C:\Program Files\Bluebeam Software\Bluebeam Revu\20\Revu\Revu32.exe"),
            //new defaultApp("BSA Assessing", @"C:\Program Files (x86)\BS&A Software\Assessing\Assessing.exe"),
            //new defaultApp("BSA Delinquent", @"C:\Program Files (x86)\BS&A Software\Delinquent Personal Property\DlqPersonalProperty.exe"),
            //new defaultApp("BSA Preaudit", @"C:\Program Files (x86)\BS&A Software\PREA\PreAudit.exe"),
            //new defaultApp("BSA Special Assessment", @"C:\Program Files (x86)\BS&A Software\Special Assessment\SpecialAssessments.exe"),
            //new defaultApp("BSA Tax", @"C:\Program Files (x86)\BS&A Software\Tax\Tax.exe"),
            //new defaultApp("Explorer", @"C:\Windows\explorer.exe"),
            //new defaultApp("Legistar", @"C:\Granicus\Legistar5.exe"),
            //new defaultApp("MiCollab", @"C:\Program Files (x86)\Mitel\MiCollab\MiCollab.exe"),
            //new defaultApp("Microsoft Project", @"C:\Program Files\Microsoft Office\root\Office16\WINPROJ.exe"),
            //new defaultApp("Microsoft Publisher", @"C:\Program Files\Microsoft Office\root\Office16\MSPUB.exe"),
            //new defaultApp("Microsoft Visio", @"C:\Program Files\Microsoft Office\root\Office16\VISIO.exe"),
            //new defaultApp("Ocularis", @"C:\Program Files\Qognify\Ocularis Client\OcularisClient.exe"),
            //new defaultApp("Onbase", @"C:\Program Files (x86)\Hyland\Unity Client\obunity.exe"),
            //new defaultApp("Trakit", @"C:\CRW\Application\TrakitClient.exe"),
            //new defaultApp("Trakit", @"C:\CRW\TrakitStart.exe"),
            //new defaultApp("1Password", @"C:\Users\npmoyer\AppData\Local\1Password\app\8\1Password.exe"),
        };
            using (TextFieldParser csvParser = new TextFieldParser(reportName))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    //read line and add each field to a entry in the array
                    string[] fields = csvParser.ReadFields();

                    //check first field to see if the prefetch file is in the defaultApps list
                    //if it is get the fields with the run count and last run dates/times
                    //index 0 = prefetch file name
                    //index 5 = exe location
                    //index 6 = Run count field 
                    //index 7 = last run dates/times
                    //This we want to change to check the app based on the app location instead of prefetch file and get the prefetch file name.
                    foreach (defaultApp app in defaultApps)
                    {

                        if (StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase))
                        {
                            app.prefetchName = fields[0];
                            app.runCount = fields[6];
                            app.lastRunTime = fields[7];
                            Assert.IsTrue(StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase));
                            BoolResult = true;
                        }
                        else
                        {
                            Assert.IsFalse(StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase));
                            BoolResult = false;
                        }
                        Assert.AreEqual(ExpectedBoolResult, BoolResult);

                    }

                }
            }


        }

        //Here the values will be equal, but case will be different. We want to ignore case so we expect the 
        //function to evaluate them as equal
        [TestMethod]
        public void TestMethod3()
        {
            const bool ExpectedBoolResult = true;
            List<defaultApp> defaultApps = new List<defaultApp>()
        {
            new defaultApp("Acrobat DC", @"C:\Program Files (x86)\ADObe\AcroBat dc\Acrobat\AcrobAT.exe"),
            //new defaultApp("Bluebeam", @"C:\Program Files\Bluebeam Software\Bluebeam Revu\20\Revu\Revu32.exe"),
            //new defaultApp("BSA Assessing", @"C:\Program Files (x86)\BS&A Software\Assessing\Assessing.exe"),
            //new defaultApp("BSA Delinquent", @"C:\Program Files (x86)\BS&A Software\Delinquent Personal Property\DlqPersonalProperty.exe"),
            //new defaultApp("BSA Preaudit", @"C:\Program Files (x86)\BS&A Software\PREA\PreAudit.exe"),
            //new defaultApp("BSA Special Assessment", @"C:\Program Files (x86)\BS&A Software\Special Assessment\SpecialAssessments.exe"),
            //new defaultApp("BSA Tax", @"C:\Program Files (x86)\BS&A Software\Tax\Tax.exe"),
            //new defaultApp("Explorer", @"C:\Windows\explorer.exe"),
            //new defaultApp("Legistar", @"C:\Granicus\Legistar5.exe"),
            //new defaultApp("MiCollab", @"C:\Program Files (x86)\Mitel\MiCollab\MiCollab.exe"),
            //new defaultApp("Microsoft Project", @"C:\Program Files\Microsoft Office\root\Office16\WINPROJ.exe"),
            //new defaultApp("Microsoft Publisher", @"C:\Program Files\Microsoft Office\root\Office16\MSPUB.exe"),
            //new defaultApp("Microsoft Visio", @"C:\Program Files\Microsoft Office\root\Office16\VISIO.exe"),
            //new defaultApp("Ocularis", @"C:\Program Files\Qognify\Ocularis Client\OcularisClient.exe"),
            //new defaultApp("Onbase", @"C:\Program Files (x86)\Hyland\Unity Client\obunity.exe"),
            //new defaultApp("Trakit", @"C:\CRW\Application\TrakitClient.exe"),
            //new defaultApp("Trakit", @"C:\CRW\TrakitStart.exe"),
            //new defaultApp("1Password", @"C:\Users\npmoyer\AppData\Local\1Password\app\8\1Password.exe"),
        };
            using (TextFieldParser csvParser = new TextFieldParser(reportName))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    //read line and add each field to a entry in the array
                    string[] fields = csvParser.ReadFields();

                    //check first field to see if the prefetch file is in the defaultApps list
                    //if it is get the fields with the run count and last run dates/times
                    //index 0 = prefetch file name
                    //index 5 = exe location
                    //index 6 = Run count field 
                    //index 7 = last run dates/times
                    //This we want to change to check the app based on the app location instead of prefetch file and get the prefetch file name.
                    foreach (defaultApp app in defaultApps)
                    {

                        if (StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase))
                        {
                            app.prefetchName = fields[0];
                            app.runCount = fields[6];
                            app.lastRunTime = fields[7];
                            Assert.IsTrue(StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase));
                            BoolResult = true;
                        }
                        else
                        {
                            Assert.IsFalse(StringCustom.Contains(fields[5], app.appLocation, StringComparison.OrdinalIgnoreCase));
                            BoolResult = false;
                        }
                        Assert.AreEqual(ExpectedBoolResult, BoolResult);

                    }

                }
            }


        }
    }
}