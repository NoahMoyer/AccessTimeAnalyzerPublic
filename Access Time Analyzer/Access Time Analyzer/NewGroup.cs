using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Access_Time_Analyzer
{
    public partial class NewGroup : Form
    {
        CSVeditor csveditor = new CSVeditor();
        SQLManager sql;
        string machineName;
        public NewGroup(SQLManager sqlinput, string MachineNameInput)
        {
            InitializeComponent();
            sql = sqlinput;
            machineName = MachineNameInput;
        }

        private void addGroupButton_Click(object sender, EventArgs e)
        {
            bool brokeLoopDueToBadData = false;
            if (groupNameTextBox.Text == "" || groupNameTextBox.Text == null)
            {
                MessageBox.Show("You must enter a group name to create a group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else if (windowsVersionTextBox.Text == "" || windowsVersionTextBox.Text == null)
            //{
            //    MessageBox.Show("You must enter a windows version to create a group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            else
            {
                AppGroup newAppGroup = new AppGroup(groupNameTextBox.Text);

                if(defaultAppGridView.Rows.Count != 0)
                {
                    for (int i = 0; i < defaultAppGridView.Rows.Count - 1; i++)
                    {
                        if(defaultAppGridView.Rows[i].Cells[0].Value != null && defaultAppGridView.Rows[i].Cells[1].Value != null && /*defaultAppGridView.Rows[i].Cells[2].Value != null &&*/
                            defaultAppGridView.Rows[i].Cells[0].Value.ToString() != "" && defaultAppGridView.Rows[i].Cells[1].Value.ToString() != "" /*&& defaultAppGridView.Rows[i].Cells[2].Value.ToString() != ""*/ &&
                            defaultAppGridView.Rows[i] != null)
                        {
                            defaultApp newApp = new defaultApp(defaultAppGridView.Rows[i].Cells[0].Value.ToString(), defaultAppGridView.Rows[i].Cells[1].Value.ToString()/*, defaultAppGridView.Rows[i].Cells[2].Value.ToString()*/);
                            newAppGroup.addApp(newApp);
                        }
                        else if (defaultAppGridView.Rows[i].Cells[0].Value == null || defaultAppGridView.Rows[i].Cells[1].Value == null || /*defaultAppGridView.Rows[i].Cells[2].Value == null ||*/
                            defaultAppGridView.Rows[i].Cells[0].Value.ToString() == "" || defaultAppGridView.Rows[i].Cells[1].Value.ToString() == "" /*|| defaultAppGridView.Rows[i].Cells[2].Value.ToString() == ""*/)
                        {
                            brokeLoopDueToBadData = true;
                            break;
                        }

                    }
                }
                if (!brokeLoopDueToBadData)
                {
                    //Updating default app list and file
                    sql.addGroup(newAppGroup/*, windowsVersionTextBox.Text*/);
                    sql.getGroupsFromDatabase(/*checkPCVersion(machineName)*/);
                    defaultAppGridView.Rows.Clear();
                    groupNameTextBox.Clear();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You can't leave any cells blank. Each one must contain information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewGroup_Load(object sender, EventArgs e)
        {
            csveditor.readDefaultAppsCSVFile();
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
