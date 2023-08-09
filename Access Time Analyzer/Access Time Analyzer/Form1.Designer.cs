namespace Access_Time_Analyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkApps = new System.Windows.Forms.Button();
            this.currentMachineNameLabel = new System.Windows.Forms.Label();
            this.recentApplicationsLabel = new System.Windows.Forms.Label();
            this.machineNameTextBox = new System.Windows.Forms.TextBox();
            this.changeMachineNameButton = new System.Windows.Forms.Button();
            this.resetMachineNameButton = new System.Windows.Forms.Button();
            this.defaultAppsSelectionBox = new System.Windows.Forms.ComboBox();
            this.defaultAppGroupsLabel = new System.Windows.Forms.Label();
            this.populateListButton = new System.Windows.Forms.Button();
            this.clearListButton = new System.Windows.Forms.Button();
            this.refreshGroupsButton = new System.Windows.Forms.Button();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.appsGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastAccessedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefetchname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Runcounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastruntime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prefecthProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.changeAppGroupsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupFileLocationLabel = new System.Windows.Forms.Label();
            this.ChangeGroupFileButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.machineWindowsVersion = new System.Windows.Forms.Label();
            this.machineVersionLabel = new System.Windows.Forms.Label();
            this.setSqlServerButton = new System.Windows.Forms.Button();
            this.sqlServerTextBox = new System.Windows.Forms.TextBox();
            this.sqlServerLabel = new System.Windows.Forms.Label();
            this.updateLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.appsGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkApps
            // 
            this.checkApps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkApps.Enabled = false;
            this.checkApps.Location = new System.Drawing.Point(669, 535);
            this.checkApps.Name = "checkApps";
            this.checkApps.Size = new System.Drawing.Size(150, 23);
            this.checkApps.TabIndex = 1;
            this.checkApps.Text = "Check Selected Apps";
            this.checkApps.UseVisualStyleBackColor = true;
            this.checkApps.Visible = false;
            this.checkApps.Click += new System.EventHandler(this.checkSelectedApps_Click);
            // 
            // currentMachineNameLabel
            // 
            this.currentMachineNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentMachineNameLabel.AutoSize = true;
            this.currentMachineNameLabel.Location = new System.Drawing.Point(57, 361);
            this.currentMachineNameLabel.Name = "currentMachineNameLabel";
            this.currentMachineNameLabel.Size = new System.Drawing.Size(119, 13);
            this.currentMachineNameLabel.TabIndex = 2;
            this.currentMachineNameLabel.Text = "Current machine name: ";
            this.currentMachineNameLabel.Click += new System.EventHandler(this.currentMachineName_Click);
            // 
            // recentApplicationsLabel
            // 
            this.recentApplicationsLabel.AutoSize = true;
            this.recentApplicationsLabel.Location = new System.Drawing.Point(86, 51);
            this.recentApplicationsLabel.Name = "recentApplicationsLabel";
            this.recentApplicationsLabel.Size = new System.Drawing.Size(102, 13);
            this.recentApplicationsLabel.TabIndex = 3;
            this.recentApplicationsLabel.Text = "Recent Applications";
            // 
            // machineNameTextBox
            // 
            this.machineNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.machineNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.machineNameTextBox.Location = new System.Drawing.Point(60, 377);
            this.machineNameTextBox.Name = "machineNameTextBox";
            this.machineNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.machineNameTextBox.TabIndex = 4;
            this.machineNameTextBox.TextChanged += new System.EventHandler(this.machineNameTextBox_TextChanged);
            // 
            // changeMachineNameButton
            // 
            this.changeMachineNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeMachineNameButton.Location = new System.Drawing.Point(215, 374);
            this.changeMachineNameButton.Name = "changeMachineNameButton";
            this.changeMachineNameButton.Size = new System.Drawing.Size(142, 23);
            this.changeMachineNameButton.TabIndex = 5;
            this.changeMachineNameButton.Text = "Change machine name";
            this.changeMachineNameButton.UseVisualStyleBackColor = true;
            this.changeMachineNameButton.Click += new System.EventHandler(this.changeMachineNameButton_Click);
            // 
            // resetMachineNameButton
            // 
            this.resetMachineNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetMachineNameButton.Location = new System.Drawing.Point(363, 374);
            this.resetMachineNameButton.Name = "resetMachineNameButton";
            this.resetMachineNameButton.Size = new System.Drawing.Size(126, 23);
            this.resetMachineNameButton.TabIndex = 6;
            this.resetMachineNameButton.Text = "Reset machine name";
            this.resetMachineNameButton.UseVisualStyleBackColor = true;
            this.resetMachineNameButton.Click += new System.EventHandler(this.resetMachineNameButton_Click);
            // 
            // defaultAppsSelectionBox
            // 
            this.defaultAppsSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultAppsSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultAppsSelectionBox.FormattingEnabled = true;
            this.defaultAppsSelectionBox.Location = new System.Drawing.Point(532, 376);
            this.defaultAppsSelectionBox.Name = "defaultAppsSelectionBox";
            this.defaultAppsSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.defaultAppsSelectionBox.TabIndex = 11;
            this.defaultAppsSelectionBox.SelectedIndexChanged += new System.EventHandler(this.defaultAppsSelectionBox_SelectedIndexChanged);
            // 
            // defaultAppGroupsLabel
            // 
            this.defaultAppGroupsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultAppGroupsLabel.AutoSize = true;
            this.defaultAppGroupsLabel.Location = new System.Drawing.Point(532, 360);
            this.defaultAppGroupsLabel.Name = "defaultAppGroupsLabel";
            this.defaultAppGroupsLabel.Size = new System.Drawing.Size(97, 13);
            this.defaultAppGroupsLabel.TabIndex = 12;
            this.defaultAppGroupsLabel.Text = "Default app groups";
            // 
            // populateListButton
            // 
            this.populateListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.populateListButton.Enabled = false;
            this.populateListButton.Location = new System.Drawing.Point(669, 477);
            this.populateListButton.Name = "populateListButton";
            this.populateListButton.Size = new System.Drawing.Size(97, 23);
            this.populateListButton.TabIndex = 13;
            this.populateListButton.Text = "Populate List";
            this.populateListButton.UseVisualStyleBackColor = true;
            this.populateListButton.Visible = false;
            this.populateListButton.Click += new System.EventHandler(this.populateListButton_Click);
            // 
            // clearListButton
            // 
            this.clearListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearListButton.Enabled = false;
            this.clearListButton.Location = new System.Drawing.Point(669, 506);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(97, 23);
            this.clearListButton.TabIndex = 14;
            this.clearListButton.Text = "Clear List";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Visible = false;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // refreshGroupsButton
            // 
            this.refreshGroupsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshGroupsButton.Location = new System.Drawing.Point(669, 376);
            this.refreshGroupsButton.Name = "refreshGroupsButton";
            this.refreshGroupsButton.Size = new System.Drawing.Size(114, 23);
            this.refreshGroupsButton.TabIndex = 15;
            this.refreshGroupsButton.Text = "Refresh Groups";
            this.refreshGroupsButton.UseVisualStyleBackColor = true;
            this.refreshGroupsButton.Click += new System.EventHandler(this.refreshGroupsButton_Click);
            // 
            // generateReportButton
            // 
            this.generateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateReportButton.Location = new System.Drawing.Point(532, 405);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(97, 23);
            this.generateReportButton.TabIndex = 16;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // appsGridView
            // 
            this.appsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.LocationColumn,
            this.LastAccessedColumn,
            this.Prefetchname,
            this.Runcounter,
            this.Lastruntime});
            this.appsGridView.Location = new System.Drawing.Point(60, 91);
            this.appsGridView.Name = "appsGridView";
            this.appsGridView.Size = new System.Drawing.Size(1003, 218);
            this.appsGridView.TabIndex = 17;
            this.appsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 60;
            // 
            // LocationColumn
            // 
            this.LocationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationColumn.HeaderText = "Location";
            this.LocationColumn.Name = "LocationColumn";
            // 
            // LastAccessedColumn
            // 
            this.LastAccessedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LastAccessedColumn.HeaderText = "Last Accessed";
            this.LastAccessedColumn.Name = "LastAccessedColumn";
            this.LastAccessedColumn.Width = 94;
            // 
            // Prefetchname
            // 
            this.Prefetchname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Prefetchname.HeaderText = "Prefetch Name";
            this.Prefetchname.Name = "Prefetchname";
            this.Prefetchname.Width = 95;
            // 
            // Runcounter
            // 
            this.Runcounter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Runcounter.FillWeight = 25F;
            this.Runcounter.HeaderText = "Run Counter";
            this.Runcounter.Name = "Runcounter";
            this.Runcounter.Width = 50;
            // 
            // Lastruntime
            // 
            this.Lastruntime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lastruntime.HeaderText = "Last Run Time";
            this.Lastruntime.Name = "Lastruntime";
            // 
            // prefecthProgressBar
            // 
            this.prefecthProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prefecthProgressBar.Enabled = false;
            this.prefecthProgressBar.Location = new System.Drawing.Point(60, 342);
            this.prefecthProgressBar.Name = "prefecthProgressBar";
            this.prefecthProgressBar.Size = new System.Drawing.Size(100, 16);
            this.prefecthProgressBar.TabIndex = 18;
            this.prefecthProgressBar.Visible = false;
            this.prefecthProgressBar.Click += new System.EventHandler(this.prefecthProgressBar_Click);
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Enabled = false;
            this.loadingLabel.Location = new System.Drawing.Point(57, 326);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(112, 13);
            this.loadingLabel.TabIndex = 19;
            this.loadingLabel.Text = "Loading prefetch file...";
            this.loadingLabel.Visible = false;
            // 
            // changeAppGroupsButton
            // 
            this.changeAppGroupsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeAppGroupsButton.Location = new System.Drawing.Point(669, 405);
            this.changeAppGroupsButton.Name = "changeAppGroupsButton";
            this.changeAppGroupsButton.Size = new System.Drawing.Size(114, 23);
            this.changeAppGroupsButton.TabIndex = 20;
            this.changeAppGroupsButton.Text = "Change app groups";
            this.changeAppGroupsButton.UseVisualStyleBackColor = true;
            this.changeAppGroupsButton.Click += new System.EventHandler(this.changeAppGroupsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Current Group File Location";
            this.label1.Visible = false;
            // 
            // groupFileLocationLabel
            // 
            this.groupFileLocationLabel.AutoSize = true;
            this.groupFileLocationLabel.Enabled = false;
            this.groupFileLocationLabel.Location = new System.Drawing.Point(3, 13);
            this.groupFileLocationLabel.Name = "groupFileLocationLabel";
            this.groupFileLocationLabel.Size = new System.Drawing.Size(36, 13);
            this.groupFileLocationLabel.TabIndex = 22;
            this.groupFileLocationLabel.Text = "Folder";
            this.groupFileLocationLabel.Visible = false;
            this.groupFileLocationLabel.Click += new System.EventHandler(this.groupFileLocationLabel_Click);
            // 
            // ChangeGroupFileButton
            // 
            this.ChangeGroupFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeGroupFileButton.Enabled = false;
            this.ChangeGroupFileButton.Location = new System.Drawing.Point(825, 534);
            this.ChangeGroupFileButton.Name = "ChangeGroupFileButton";
            this.ChangeGroupFileButton.Size = new System.Drawing.Size(114, 23);
            this.ChangeGroupFileButton.TabIndex = 23;
            this.ChangeGroupFileButton.Text = "Change Group File";
            this.ChangeGroupFileButton.UseVisualStyleBackColor = true;
            this.ChangeGroupFileButton.Visible = false;
            this.ChangeGroupFileButton.Click += new System.EventHandler(this.ChangeGroupFileButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.groupFileLocationLabel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(825, 475);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 53);
            this.flowLayoutPanel1.TabIndex = 24;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(1084, 539);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(95, 13);
            this.versionLabel.TabIndex = 25;
            this.versionLabel.Text = "Version: NUMBER";
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // machineWindowsVersion
            // 
            this.machineWindowsVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.machineWindowsVersion.AutoSize = true;
            this.machineWindowsVersion.Location = new System.Drawing.Point(192, 417);
            this.machineWindowsVersion.Name = "machineWindowsVersion";
            this.machineWindowsVersion.Size = new System.Drawing.Size(133, 13);
            this.machineWindowsVersion.TabIndex = 26;
            this.machineWindowsVersion.Text = "Machine Windows Version";
            // 
            // machineVersionLabel
            // 
            this.machineVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.machineVersionLabel.AutoSize = true;
            this.machineVersionLabel.Location = new System.Drawing.Point(57, 417);
            this.machineVersionLabel.Name = "machineVersionLabel";
            this.machineVersionLabel.Size = new System.Drawing.Size(139, 13);
            this.machineVersionLabel.TabIndex = 27;
            this.machineVersionLabel.Text = "Detected Windows Version:";
            // 
            // setSqlServerButton
            // 
            this.setSqlServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setSqlServerButton.Location = new System.Drawing.Point(931, 374);
            this.setSqlServerButton.Name = "setSqlServerButton";
            this.setSqlServerButton.Size = new System.Drawing.Size(93, 23);
            this.setSqlServerButton.TabIndex = 28;
            this.setSqlServerButton.Text = "Set SQL server";
            this.setSqlServerButton.UseVisualStyleBackColor = true;
            this.setSqlServerButton.Click += new System.EventHandler(this.setSqlServerButton_Click);
            // 
            // sqlServerTextBox
            // 
            this.sqlServerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlServerTextBox.Location = new System.Drawing.Point(825, 376);
            this.sqlServerTextBox.Name = "sqlServerTextBox";
            this.sqlServerTextBox.Size = new System.Drawing.Size(100, 20);
            this.sqlServerTextBox.TabIndex = 29;
            this.sqlServerTextBox.TextChanged += new System.EventHandler(this.sqlServerTextBox_TextChanged);
            // 
            // sqlServerLabel
            // 
            this.sqlServerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlServerLabel.AutoSize = true;
            this.sqlServerLabel.Location = new System.Drawing.Point(825, 360);
            this.sqlServerLabel.Name = "sqlServerLabel";
            this.sqlServerLabel.Size = new System.Drawing.Size(60, 13);
            this.sqlServerLabel.TabIndex = 30;
            this.sqlServerLabel.Text = "SQL server";
            // 
            // updateLink
            // 
            this.updateLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateLink.AutoSize = true;
            this.updateLink.Location = new System.Drawing.Point(991, 539);
            this.updateLink.Name = "updateLink";
            this.updateLink.Size = new System.Drawing.Size(87, 13);
            this.updateLink.TabIndex = 31;
            this.updateLink.TabStop = true;
            this.updateLink.Text = "Update available";
            this.updateLink.Visible = false;
            this.updateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.updateLink);
            this.Controls.Add(this.sqlServerLabel);
            this.Controls.Add(this.sqlServerTextBox);
            this.Controls.Add(this.setSqlServerButton);
            this.Controls.Add(this.machineVersionLabel);
            this.Controls.Add(this.machineWindowsVersion);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.changeAppGroupsButton);
            this.Controls.Add(this.ChangeGroupFileButton);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.prefecthProgressBar);
            this.Controls.Add(this.appsGridView);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.refreshGroupsButton);
            this.Controls.Add(this.clearListButton);
            this.Controls.Add(this.populateListButton);
            this.Controls.Add(this.defaultAppGroupsLabel);
            this.Controls.Add(this.defaultAppsSelectionBox);
            this.Controls.Add(this.resetMachineNameButton);
            this.Controls.Add(this.changeMachineNameButton);
            this.Controls.Add(this.machineNameTextBox);
            this.Controls.Add(this.recentApplicationsLabel);
            this.Controls.Add(this.currentMachineNameLabel);
            this.Controls.Add(this.checkApps);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "Form1";
            this.Text = "Access Time Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appsGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button checkApps;
        private System.Windows.Forms.Label currentMachineNameLabel;
        private System.Windows.Forms.Label recentApplicationsLabel;
        private System.Windows.Forms.TextBox machineNameTextBox;
        private System.Windows.Forms.Button changeMachineNameButton;
        private System.Windows.Forms.Button resetMachineNameButton;
        private System.Windows.Forms.ComboBox defaultAppsSelectionBox;
        private System.Windows.Forms.Label defaultAppGroupsLabel;
        private System.Windows.Forms.Button populateListButton;
        private System.Windows.Forms.Button clearListButton;
        private System.Windows.Forms.Button refreshGroupsButton;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.DataGridView appsGridView;
        private System.Windows.Forms.ProgressBar prefecthProgressBar;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Button changeAppGroupsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label groupFileLocationLabel;
        private System.Windows.Forms.Button ChangeGroupFileButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label machineWindowsVersion;
        private System.Windows.Forms.Label machineVersionLabel;
        private System.Windows.Forms.Button setSqlServerButton;
        private System.Windows.Forms.TextBox sqlServerTextBox;
        private System.Windows.Forms.Label sqlServerLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastAccessedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefetchname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Runcounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastruntime;
        private System.Windows.Forms.LinkLabel updateLink;
    }
}

