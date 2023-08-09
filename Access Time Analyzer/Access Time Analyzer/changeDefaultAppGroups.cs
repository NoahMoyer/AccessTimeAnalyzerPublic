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
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace Access_Time_Analyzer
{
    public partial class changeDefaultAppGroups : Form
    {
        CSVeditor csveditor = new CSVeditor();//editor for file containing app groups
        SQLManager sql;
        string machineName;
        //bool isWindowsVersionChangeCodeTriggered = false; //default value is false
        bool isappSelectionCodeTriggered = false;
        public changeDefaultAppGroups(SQLManager sqlInput, string machineNameInput)
        {
            sql= sqlInput;
            machineName= machineNameInput;
            InitializeComponent();
        }

        private void changeDefaultAppGroups_Load(object sender, EventArgs e)
        {
            refreshGroups(true);
            //isWindowsVersionChangeCodeTriggered = true;
            //windowsVersionCombobox.SelectedItem = checkPCVersion(machineName);
            //isWindowsVersionChangeCodeTriggered = false;
        }
        //clear all but selected items from comboboxes
        public void clearAllButSelected()
        {
            var tempAppSelectionObject = appGroupSelection.SelectedItem;
            //var tempWindowsVersionSelection = windowsVersionCombobox.SelectedItem;
            if(tempAppSelectionObject != null)
            {
                appGroupSelection.Items.Clear();
                appGroupSelection.Items.Add(tempAppSelectionObject);
            }
            //if (tempWindowsVersionSelection != null)
            //{
            //    windowsVersionCombobox.Items.Clear();
            //    windowsVersionCombobox.Items.Add(tempWindowsVersionSelection);
            //}
            
            //appGroupSelection.SelectedItem = tempAppSelectionObject;//trying to set it to the first item on the list since this should be the only one on the list
            //windowsVersionCombobox.SelectedItem = tempWindowsVersionSelection;
        }
        
        //refreshes group based on current machine
        public void refreshGroups(bool clearSelectedItem)
        {
            if (clearSelectedItem)
            {
                appGroupSelection.Items.Clear();
                //windowsVersionCombobox.Items.Clear();
            }
            else if (!clearSelectedItem)
            {
                clearAllButSelected();
            }
            sql.getGroupsFromDatabase(/*checkPCVersion(machineName)*/);
            //sql.getWindowsVersionsInDatabase();
            foreach (AppGroup group in sql.AppGroups)
            {
                appGroupSelection.Items.Add(group.getGroupName());
            }
            //foreach(string windowsVersionList in sql.windowsVersions)
            //{
            //    windowsVersionCombobox.Items.Add(windowsVersionList);
            //}
        }
        //public void refreshGroups(string windowsVersion, bool clearSelectedItem)
        //{
        //    if (clearSelectedItem)
        //    {
        //        appGroupSelection.Items.Clear();
        //        windowsVersionCombobox.Items.Clear();
        //    }
        //    else if (!clearSelectedItem)
        //    {
        //        clearAllButSelected();
        //    }
        //    sql.getGroupsFromDatabase(/*windowsVersion*/);
        //    sql.getWindowsVersionsInDatabase();
        //    foreach (AppGroup group in sql.AppGroups)
        //    {
        //        appGroupSelection.Items.Add(group.getGroupName());
        //    }
        //    foreach (string windowsVersionList in sql.windowsVersions)
        //    {
        //        windowsVersionCombobox.Items.Add(windowsVersionList);
        //    }
        //}
        //public void refreshAppGroupsBasedOnSelectedWindowsVersion(string windowsVersion)
        //{
        //    appGroupSelection.Items.Clear();
        //    appGroupSelection.Text = "";
        //    sql.getGroupsFromDatabase(/*windowsVersionCombobox.SelectedItem.ToString()*/);
        //    foreach (AppGroup group in sql.AppGroups)
        //    {
        //        appGroupSelection.Items.Add(group.getGroupName());
        //    }
        //}
        private void windowsVersionCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!isWindowsVersionChangeCodeTriggered)
            //{
            //    defaultAppGridView.Rows.Clear();
            //    refreshAppGroupsBasedOnSelectedWindowsVersion(windowsVersionCombobox.Text);
            //}
        }
        private void appGroupSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isappSelectionCodeTriggered)
            {
                defaultAppGridView.Rows.Clear();
                foreach (AppGroup group in sql.AppGroups)
                {
                    if (group.getGroupName() == appGroupSelection.Text)
                    {
                        int i = 0;
                        foreach (defaultApp app in group.defaultApps)
                        {
                            defaultAppGridView.Rows.Add();
                            defaultAppGridView.Rows[i].Cells[0].Value = app.appName;
                            defaultAppGridView.Rows[i].Cells[1].Value = app.appLocation;
                            //defaultAppGridView.Rows[i].Cells[2].Value = app.prefetchName;
                            i++;
                        }
                    }

                }
            }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool brokeLoopDueToBadData = false;
            //need to update apps based on selected app group
            defaultApp tempApp = new defaultApp("tempName", "tempLocation"/*, "tempPrefetchName"*/);
            foreach(AppGroup group in sql.AppGroups)
            {
                if (appGroupSelection.Text == group.getGroupName())
                {
                    group.defaultApps.Clear();
                    for(int i = 0; i < defaultAppGridView.Rows.Count - 1; i++)
                    {
                        if (defaultAppGridView.Rows[i].Cells[0].Value != null && defaultAppGridView.Rows[i].Cells[1].Value != null && /*defaultAppGridView.Rows[i].Cells[2].Value != null &&*/
                            defaultAppGridView.Rows[i].Cells[0].Value.ToString() != "" && defaultAppGridView.Rows[i].Cells[1].Value.ToString() != "" /*&& defaultAppGridView.Rows[i].Cells[2].Value.ToString() != ""*/)
                        {
                            tempApp = new defaultApp(defaultAppGridView.Rows[i].Cells[0].Value.ToString(), defaultAppGridView.Rows[i].Cells[1].Value.ToString()/*, defaultAppGridView.Rows[i].Cells[2].Value.ToString()*/);
                            group.addApp(tempApp);
                        }
                        else if(defaultAppGridView.Rows[i].Cells[0].Value == null || defaultAppGridView.Rows[i].Cells[1].Value == null || /*defaultAppGridView.Rows[i].Cells[2].Value == null ||*/
                            defaultAppGridView.Rows[i].Cells[0].Value.ToString() == "" || defaultAppGridView.Rows[i].Cells[1].Value.ToString() == "" /*|| defaultAppGridView.Rows[i].Cells[2].Value.ToString() == ""*/)
                        {
                            brokeLoopDueToBadData = true;
                            break;
                        }
                        
                    }
                    if (!brokeLoopDueToBadData)
                    {
                        sql.updateGroup(group/*, checkPCVersion(machineName)*/);
                    }
                    
                }
            }
            //csveditor.updateDefaultAppsCSVFile();
            if (!brokeLoopDueToBadData)
            {
                refreshGroups(/*windowsVersionCombobox.Text,*/ true);
            }
            else
            {
                sql.getGroupsFromDatabase(/*checkPCVersion(machineName)*/);//put data back into groups. We don't want to make any changes if the data contained empty cells
                MessageBox.Show("You can't leave any cells blank. Each one must contain information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                brokeLoopDueToBadData = false;
            }
        }

        private void refreshGroupsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void addNewGroupButton_Click(object sender, EventArgs e)
        {
            NewGroup newGroupPopUp = new NewGroup(sql, machineName);
            DialogResult dialogResult = newGroupPopUp.ShowDialog();
            if(dialogResult == DialogResult.Cancel)//if the user clicks the x button to close the windwow
            {
                refreshGroups(/*windowsVersionCombobox.Text,*/ true); //may need to change this somehow. not sure
            }
            if(dialogResult == DialogResult.OK)//when the user creates a new group
            {
                refreshGroups(/*windowsVersionCombobox.Text,*/ true); //may need to change this somehow. not sure
            }
        }

        private void deleteCurrentGroupButton_Click(object sender, EventArgs e)
        {

            foreach(AppGroup group in sql.AppGroups)
            {
                if (appGroupSelection.SelectedIndex != -1)
                {
                    if (group.getGroupName() == appGroupSelection.SelectedItem.ToString())
                    {
                        DialogResult deleteConfirmation = new DialogResult();
                        deleteConfirmation = MessageBox.Show("Are you sure you want to delete the current app group? This cannot be undone.", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (deleteConfirmation == DialogResult.Yes)
                        {
                            sql.removeGroup(group/*, windowsVersionCombobox.Text*/);
                            sql.getGroupsFromDatabase(/*windowsVersionCombobox.Text*/);
                            refreshGroups(true);
                            return;
                        }
                        appGroupSelection.Text = "";
                        //isappSelectionCodeTriggered= true;
                        //appGroupSelection.SelectedIndex = -1; //trying to reset the selected item since the current one was deleted
                        //isappSelectionCodeTriggered= false;
                        defaultAppGridView.Rows.Clear();
                    }
                }
                
            }
        }

        public string checkPCVersion(string machineNameInput)
        {
            string path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            RegistryKey rk = null;
            rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineNameInput);
            var key = rk.OpenSubKey(path);
            string displayVersion = key.GetValue("displayVersion").ToString();
            return displayVersion;
        }

        
    }
}
