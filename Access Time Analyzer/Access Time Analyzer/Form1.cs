using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System.Collections;

namespace Access_Time_Analyzer
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog(); //file dialog for selecting applications to look at
        CSVeditor csveditor = new CSVeditor();//editor for file containing app groups
        List<string> fileReport = new List<string>();
        public string machineName;
        string prefetchReportName = "prefetchReport.csv";
        AppGroup selectedAppGroup;
        bool selectionChangedCodeTriggered;
        string SQLServer;
        Settings settingsManager = new Settings();//this will get the settings when the object is created here

            

    //this will connect to the database with the current windows user
    SQLManager sql;
        private void setSqlServerButton_Click(object sender, EventArgs e)
        {
            SQLServer = sqlServerTextBox.Text;
            settingsManager.sqlServerName = SQLServer;
            settingsManager.setSettings();
            sql.closeSqlConnection();
            sqlServerTextBox.Text = SQLServer;
            sql = new SQLManager();
            if (!sql.connectToSqlServer($"Data Source={SQLServer};Initial Catalog=AccessTime;Integrated Security=True;"))
            {
                MessageBox.Show($"Connection to the SQL server {SQLServer} was not successful. Please make sure the server is accesible and try again.", "SQL connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, false);
            }
            else
            {
                clearData();
                refreshGroups();
            }
        }
        public Form1()
        {
            InitializeComponent();
            rerunFormSetup();

            //checking for upate
            Update x = new Update();
            if (x.updateAvail)
            {
                this.updateLink.Visible = true;
            }

            //Setting version lable on GUI
            //string versionFile = "version.md";
            //string version = File.ReadAllText(versionFile);
            var tempVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string version = tempVersion.ToString();
            this.versionLabel.Text = "Version: " + version;
        }
        public void rerunFormSetup()
        {
            machineWindowsVersion.Text = checkPCVersion(true);
            SQLServer = settingsManager.sqlServerName;
            sqlServerTextBox.Text = SQLServer;
            sql = new SQLManager();
            
            if (!sql.connectToSqlServer($"Data Source={SQLServer};Initial Catalog=AccessTime;Integrated Security=True;"))
            {
                MessageBox.Show($"Connection to the SQL server {SQLServer} was not successful. Please make sure the server is accesible and try again.", "SQL connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, false);
                //open menu to provide new server name
                sqlConnectionError popUp = new sqlConnectionError();
                DialogResult result = popUp.ShowDialog();//this menu shoud change the sql server
                SQLServer = popUp.SqlServer;
                settingsManager.sqlServerName = SQLServer;
                settingsManager.setSettings();
                rerunFormSetup();//want to run this until a successful connection
            }
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("Form closed.");
            sql.closeSqlConnection();//Closing the sql server connection as the application closes
        }
        public string checkPCVersion(bool localPC)
        {
            string path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            RegistryKey rk = null;

            if (localPC == true)
            {
                rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            }
            else if(localPC == false)
            {
                machineName = machineNameTextBox.Text;
                rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName);
            }
                        
            var key = rk.OpenSubKey(path);
            string displayVersion = key.GetValue("displayVersion").ToString();
            return displayVersion;
        }
        public void checkSelectedApps()
        {
            this.AcceptButton = generateReportButton;
            string tempValue;
            //string appLocaiton;
            FileInfo file = null;
            DateTime lastAccessed = DateTime.Parse("6/12/1997 9:00:00 AM");//set initial value
            string runCount = "";
            string lastRunDate = "";
            string prefetchFileName = "";

            //getting data from prefetch report
            try
            {
                if(selectedAppGroup!= null)
                {
                    csveditor.readPrefetcCSVFile(machineName + prefetchReportName, ref selectedAppGroup.defaultApps);
                    File.Delete(machineName + prefetchReportName);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                File.Delete(machineName + prefetchReportName);
            }
            
            //selecting app group
            //foreach (AppGroup group in csveditor.AppGroups)
            foreach (AppGroup group in sql.AppGroups)
            {
                if (defaultAppsSelectionBox.Text == group.getGroupName())
                {
                    selectedAppGroup = group;
                }
            }

            //string appNameInList;
            //loop through apps in display
            for (int i = 0; i < appsGridView.Rows.Count - 1; i++)
            {
                tempValue = "";
                //appNameInList = appsGridView.Rows[i].Cells[0].Value.ToString();
                if (selectedAppGroup == null)
                {
                    break;
                }
                //loop through defaultApps list in selected group
                foreach (defaultApp app in selectedAppGroup.defaultApps)
                {
                    //do this once we get to the app in the display that mathces the app in the group
                    if (appsGridView.Rows[i].Cells[0].Value.ToString() == app.appName)
                    {
                        file = new FileInfo(app.appLocation);
                        if (file.Exists)
                        {
                            lastAccessed = file.LastAccessTime;//gets time app was last accessed

                        }
                        else if (!file.Exists)
                        {
                            lastAccessed = DateTime.Parse("6/12/1400 9:00:00 AM");
                        }
                        //TODO: need to get data from prefetchCSVfile
                        runCount = app.runCount;
                        lastRunDate = app.lastRunTime;
                        prefetchFileName = app.prefetchName;
                    }
                }



                //using gridViewBox for better data veiwing

                if (lastAccessed.ToString() == "6/12/1400 9:00:00 AM")
                {
                    appsGridView.Rows[i].Cells[2].Value = "App not installed/not accessible";
                }
                else
                {

                    appsGridView.Rows[i].Cells[2].Value = lastAccessed.ToString();
                    appsGridView.Rows[i].Cells[3].Value = prefetchFileName;
                    appsGridView.Rows[i].Cells[4].Value = runCount;
                    appsGridView.Rows[i].Cells[5].Value = lastRunDate;

                }


                //chandge entry to add access time to the end of the line displaying the app
                const string quote = "\"";
                tempValue = appsGridView.Rows[i].Cells[0].Value + ",Last accessed," + appsGridView.Rows[i].Cells[2].Value.ToString() + ",Run count," + quote + runCount + quote + ",Last run dates," + quote + lastRunDate + quote;
                //add the same line from the display to the report
                fileReport.Add(tempValue); //add string to file report list so we can generate report later when the button is clicked
            }
            //allow report to be generated
            generateReportButton.Enabled = true;
        }

        //check selected apps
        private void checkSelectedApps_Click(object sender, EventArgs e)
        {
            //checkSelectedApps();
        }

        private void currentMachineName_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshGroups();

        }


        //TODO: need to make the prefetch file report able to access prefetch files over the network
        //change current machine to typed one
        private async void changeMachineNameButton_Click(object sender, EventArgs e)
        {
            //clearData();

            

            loadingLabel.Enabled = true;
            loadingLabel.Visible = true;
            prefecthProgressBar.Enabled = true;
            prefecthProgressBar.Visible = true;
            checkApps.Enabled = false;
            DialogResult timeoutDialogResult;

            machineName = machineNameTextBox.Text;
            currentMachineNameLabel.Text = "Current machine name: " + machineName;

            string prefetchFileName = machineName + prefetchReportName;

            //delete old prefetch file
            if (csveditor.checkForPrefetchFile(prefetchFileName))
            {
                File.Delete(prefetchFileName);
                //wait for the file to be deleted
                while(csveditor.checkForPrefetchFile(prefetchFileName))
                {
                    await Task.Delay(200);
                }
                //Wait so we are not checking for the file instantly after deleting it
                await Task.Delay(500);
            }

            

            //would like to be able to check computers over the network. Will attempt that here by changing location from C: to \\machinename\location
            clearData();

            //testing out using a sql database instead
            sql.getGroupsFromDatabase(/*checkPCVersion(false)*/);
            foreach (AppGroup group in sql.AppGroups)
            {
                defaultAppsSelectionBox.Items.Add(group.getGroupName());
            }

            //need to reset app location settings. This is causing an issue with appending machine names when checking multiple computers
            //csveditor.readDefaultAppsCSVFile();
            //foreach (AppGroup group in csveditor.AppGroups)
            foreach (AppGroup group in sql.AppGroups)
            {
                if (group.getGroupName() == defaultAppsSelectionBox.Text)
                {
                    
                    foreach (defaultApp app in group.defaultApps)
                    {
                        string secondPartOfString = app.appLocation.Substring(2);
                        app.appLocation = "\\\\" + machineName + "\\C$" + secondPartOfString;
                        //appsListBox.Items.Add(app.getAppName() + " " + app.getAppLocation());
                    }
                }
            }
            //this should change the locations to the network based location of another machine
            prefecthProgressBar.Value = 5;
            csveditor.runPrefetchReportCommandOverNetwork(machineName + prefetchReportName, machineName);

            bool timedOut = false; //initialize to false as it hasn't timed out yet
            //waiting for prefetch report so we don't try to access it before it exists
            int timeout = 0;
            while (!(csveditor.checkForPrefetchFile(prefetchFileName)))
            {
                //timeout after specified seconds in case computer is unreachable
                if (timeout >= 90)
                {
                    timeoutDialogResult = MessageBox.Show("Either the computer is offline or name was input incorrectly.", "Machine unreachable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (timeoutDialogResult == System.Windows.Forms.DialogResult.OK || timeoutDialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        checkApps.Enabled = false;
                        timedOut = true;
                        break;
                    }

                }
                await Task.Delay(1000);
                prefecthProgressBar.Value++;
                timeout++;
                Debug.WriteLine("waiting for prefetch file... " + timeout + " " + prefetchFileName);
            }
            prefecthProgressBar.Value = 100;
            await Task.Delay(300);


            if (!timedOut)
            {
                //when the name is changed we will want to update the app group based on the name
                //foreach (AppGroup group in csveditor.AppGroups)
                foreach (AppGroup group in sql.AppGroups)
                {

                    if (machineName.StartsWith(group.getGroupName()) /*&& defaultAppsSelectionBox.Items.Contains(Environment.MachineName.StartsWith(group.getGroupName()))*/)
                    {

                        //defaultAppsSelectionBox.SelectedItem = defaultAppsSelectionBox.FindString(group.getGroupName());

                        //we need to unbind the event trigger for the combobox so we don't trigger the event call here then rebind it after changin the value
                        selectionChangedCodeTriggered = true;
                        defaultAppsSelectionBox.Text = group.getGroupName();
                        selectionChangedCodeTriggered = false;


                        selectedAppGroup = group;
                        break;
                    }

                }

                //Check if prefetch file exists then check if it has anything in it before enabling the "Check selected apps" button
                if (File.Exists(prefetchFileName))
                {
                    if (new FileInfo(prefetchFileName).Length == 0)
                    {
                        MessageBox.Show("Either the computer is offline or there is an IP issue. Please make sure computer is reachable via hostname.", "Machine unreachable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkApps.Enabled = false;
                        machineWindowsVersion.Text = "Computer offline";
                    }
                    else
                    {
                        checkApps.Enabled = true;
                        machineWindowsVersion.Text = checkPCVersion(false); //only want to do this if the machine is reachable. Otherwise this won't work.
                    }
                }
                

                //trying to automate the populate list and check apps buttons
                populateList();
                checkSelectedApps();
                
            }
            loadingLabel.Enabled = false;
            loadingLabel.Visible = false;
            prefecthProgressBar.Enabled = false;
            prefecthProgressBar.Visible = false;
            
        }



        //reset machine name to current machine
        private void resetMachineNameButton_Click(object sender, EventArgs e)
        {
            clearData();
            refreshGroups();
            
        }

        //brings up the list of apps for the computer that is being analyzed
        private void populateListButton_Click(object sender, EventArgs e)
        {
            //populateList();
        }
        public void populateList()
        {
            //this.AcceptButton = checkApps;
            //populate app list based on selected group name
            if (defaultAppsSelectionBox.SelectedItem != null)
            {
                //foreach (AppGroup group in csveditor.AppGroups)
                foreach (AppGroup group in sql.AppGroups) //Testing this with data from sql database
                {
                    if (group.getGroupName() == defaultAppsSelectionBox.SelectedItem.ToString())
                    {

                        foreach (defaultApp app in group.getAppsList())
                        {
                            //appsListBox.Items.Add(app.appName + " " + app.appLocation);

                            //using gridViewBox for better data veiwing
                            int n = appsGridView.Rows.Add();
                            appsGridView.Rows[n].Cells[0].Value = app.appName;
                            appsGridView.Rows[n].Cells[1].Value = app.appLocation;
                            
                        }
                        break;
                    }
                }

            }
        }

        //clears the list of apps
        private void clearListButton_Click(object sender, EventArgs e)
        {
            //clearData();
        }

        public void clearData()
        {
            //appsListBox.Items.Clear();
            appsGridView.Rows.Clear();
            fileReport.Clear();
            generateReportButton.Enabled = false;

            defaultAppsSelectionBox.Items.Clear();
        }

        private void refreshGroupsButton_Click(object sender, EventArgs e)
        {
            clearData();
            refreshGroups();
        }
        //refreshses groups from default app group list file
        //Currently doesn't seem to function as expected
        public async void refreshGroups()
        {
            loadingLabel.Enabled = true;
            loadingLabel.Visible = true;
            prefecthProgressBar.Enabled = true;
            prefecthProgressBar.Visible = true;
            checkApps.Enabled = false;

            //using a sql database instead
            sql.getGroupsFromDatabase(/*checkPCVersion(true)*/);

           
            foreach (AppGroup group in sql.AppGroups)
            {
                defaultAppsSelectionBox.Items.Add(group.getGroupName());
            }
            


            //update machine name to current machine when form loads
            machineName = Environment.MachineName;
            currentMachineNameLabel.Text = "Current machine name: " + machineName; //load current machine name

            string prefetchFileName = machineName + prefetchReportName;

            //delete old prefetch file
            if (csveditor.checkForPrefetchFile(prefetchFileName))
            {
                File.Delete(prefetchFileName);
                //wait for the file to be deleted
                while (csveditor.checkForPrefetchFile(prefetchFileName))
                {
                    await Task.Delay(200);
                }
                //Wait so we are not checking for the file instantly after deleting it
                await Task.Delay(500);
            }

            //need to generate report from WinPrefetchView on prefetch files and parse the data
            prefecthProgressBar.Value = 5;
            csveditor.runPrefetchReportCommand(machineName + prefetchReportName);

            //waiting for prefetch report so we don't try to access it before it exists
            while (!csveditor.checkForPrefetchFile(prefetchFileName))
            {
                await Task.Delay(500);
                Debug.WriteLine("waiting for prefetch file... " + prefetchFileName);
            }

            //TODO
            //when form loads we want to select the app group based on the prefix of the computer name
            //foreach (AppGroup group in csveditor.AppGroups)
            foreach (AppGroup group in sql.AppGroups)
            {

                if (machineName.StartsWith(group.getGroupName()) /*&& defaultAppsSelectionBox.Items.Contains(Environment.MachineName.StartsWith(group.getGroupName()))*/)
                {
                    //we need to unbind the event trigger for the combobox so we don't trigger the event call here then rebind it after changin the value
                    selectionChangedCodeTriggered = true;
                    defaultAppsSelectionBox.Text = group.getGroupName();
                    selectionChangedCodeTriggered = false;
                    selectedAppGroup = group;
                }
            }
            generateReportButton.Enabled = false;

            int timeout = 0;
            while (!(csveditor.checkForPrefetchFile(prefetchFileName)))
            {
                //timeout after specified seconds in case computer is unreachable
                if (timeout >= 90)
                {
                    MessageBox.Show("Either the computer is offline or name was input incorrectly.", "Machine unreachable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                await Task.Delay(1000);
                timeout++;
                prefecthProgressBar.Value++;
            }
            prefecthProgressBar.Value = 100;
            await Task.Delay(300);

            checkApps.Enabled = true;
            loadingLabel.Enabled = false;
            loadingLabel.Visible = false;
            prefecthProgressBar.Enabled = false;
            prefecthProgressBar.Visible = false;

            populateList();
            //right now for some reason the current machine is not showing the run count data. Maybe it just doesn't like my computer?
            //Seems to be an issue with IT2282L. Prefetch file names are all different. I know mine updated to 22H2. Maybe that's the issue?
            checkSelectedApps();
        }
        public static string reportName;
        //generate report based on apps generated
        private void generateReportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV file|*.csv";
            saveFileDialog1.Title = "Save Prefetch Report File";
            saveFileDialog1.ShowDialog();
          
            reportName = csveditor.generateReport(fileReport, machineName, saveFileDialog1.FileName);
            MessageBox.Show($"Prefetch file saved as {saveFileDialog1.FileName}", "Prefetch File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void machineNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = changeMachineNameButton;
        }
        public void clearDataExceptDefaultAppsSelectionBox()
        {
            appsGridView.Rows.Clear();
            fileReport.Clear();
            generateReportButton.Enabled = false;
        }
        private void defaultAppsSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!selectionChangedCodeTriggered)//we only want to do this if the change was trigger by the user in the UI or areas in code we want it triggered. This will allow us to change the value without this function running.
            {
                clearDataExceptDefaultAppsSelectionBox();
                //foreach (AppGroup group in csveditor.AppGroups)
                foreach (AppGroup group in sql.AppGroups)
                {
                    if (group.getGroupName() == defaultAppsSelectionBox.Text)
                    {
                        selectedAppGroup = group;
                    }
                }
                //we want to recheck the apps when we change the app group so the user can check different groups if they want to
                populateList();
                checkSelectedApps();
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void changeAppGroupsButton_Click(object sender, EventArgs e)
        {
            //bring menu up to change default app groups
            changeDefaultAppGroups popUp = new changeDefaultAppGroups(sql, machineName);
            DialogResult result = popUp.ShowDialog();
            //popUp.Show();
            if (result == DialogResult.Cancel)//this will be called when the window is closed. Should refresh the default groups with the new data
            {
                //MessageBox.Show("Refreshed groups");
                //TODO: make sure this refreshes default app groups when closing the options menu
                clearData();
                refreshGroups();
            }
        }
        //allows user to change the default app list file
        private void ChangeGroupFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV file|*.csv";
            openFileDialog1.Title = "Select new default app list";
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                if (!(openFileDialog1.FileName == "" || openFileDialog1.FileName == null))
                {
                    //Name is not empty
                    csveditor.changeSettings(openFileDialog1.FileName);
                    groupFileLocationLabel.Text = openFileDialog1.FileName;
                }
                else
                {
                    //name is empty
                }
            }
            else if (!(File.Exists(openFileDialog1.FileName)) && !(openFileDialog1.FileName == "" || openFileDialog1.FileName == null))//checking if the file does not exist and that the user has not clicked close or cancel
            {
                MessageBox.Show("Default app list file does not exist. Pleast choose another file.", "Default app file does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeGroupFileButton_Click(sender, e);
            }
            refreshGroups();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupFileLocationLabel_Click(object sender, EventArgs e)
        {

        }

        private void sqlServerTextBox_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = setSqlServerButton;
        }

        private void prefecthProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void updateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process.Start("C:\\Users\\NMoyer\\OneDrive - City of Ann Arbor\\Documents\\GitHub\\AccessTimeAnalyzer\\Access Time Analyzer\\updater\\bin\\Debug\\net6.0-windows\\updater.exe");
            //Process.Start(@"update\updater.exe");

            //bring menu up to change default app groups
            UpdateConfirmation popUp = new UpdateConfirmation();
            DialogResult result = popUp.ShowDialog();
            //popUp.Show();
            //if (result == DialogResult.Cancel)//this will be called when the window is closed. Should refresh the default groups with the new data
            //{
            //    //MessageBox.Show("Refreshed groups");
            //    //TODO: make sure this refreshes default app groups when closing the options menu
            //    clearData();
            //    refreshGroups();
            //}
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {

        }
    }
    }

