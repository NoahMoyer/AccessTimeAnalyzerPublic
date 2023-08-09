namespace Access_Time_Analyzer
{
    partial class changeDefaultAppGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeDefaultAppGroups));
            this.appGroupSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultAppGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.addNewGroupButton = new System.Windows.Forms.Button();
            this.deleteCurrentGroupButton = new System.Windows.Forms.Button();
            this.windowsVersionLabel = new System.Windows.Forms.Label();
            this.windowsVersionCombobox = new System.Windows.Forms.ComboBox();
            this.appName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.defaultAppGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appGroupSelection
            // 
            this.appGroupSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appGroupSelection.FormattingEnabled = true;
            this.appGroupSelection.Location = new System.Drawing.Point(12, 59);
            this.appGroupSelection.Name = "appGroupSelection";
            this.appGroupSelection.Size = new System.Drawing.Size(155, 21);
            this.appGroupSelection.TabIndex = 0;
            this.appGroupSelection.SelectedIndexChanged += new System.EventHandler(this.appGroupSelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "App Group";
            // 
            // defaultAppGridView
            // 
            this.defaultAppGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultAppGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.defaultAppGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appName,
            this.appLocation});
            this.defaultAppGridView.Location = new System.Drawing.Point(12, 86);
            this.defaultAppGridView.Name = "defaultAppGridView";
            this.defaultAppGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.defaultAppGridView.Size = new System.Drawing.Size(810, 342);
            this.defaultAppGridView.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(747, 434);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addNewGroupButton
            // 
            this.addNewGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewGroupButton.Location = new System.Drawing.Point(699, 12);
            this.addNewGroupButton.Name = "addNewGroupButton";
            this.addNewGroupButton.Size = new System.Drawing.Size(123, 23);
            this.addNewGroupButton.TabIndex = 4;
            this.addNewGroupButton.TabStop = false;
            this.addNewGroupButton.Text = "Add new group";
            this.addNewGroupButton.UseVisualStyleBackColor = true;
            this.addNewGroupButton.Click += new System.EventHandler(this.addNewGroupButton_Click);
            // 
            // deleteCurrentGroupButton
            // 
            this.deleteCurrentGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteCurrentGroupButton.Location = new System.Drawing.Point(699, 45);
            this.deleteCurrentGroupButton.Name = "deleteCurrentGroupButton";
            this.deleteCurrentGroupButton.Size = new System.Drawing.Size(123, 23);
            this.deleteCurrentGroupButton.TabIndex = 5;
            this.deleteCurrentGroupButton.TabStop = false;
            this.deleteCurrentGroupButton.Text = "Delete Current Group";
            this.deleteCurrentGroupButton.UseVisualStyleBackColor = true;
            this.deleteCurrentGroupButton.Click += new System.EventHandler(this.deleteCurrentGroupButton_Click);
            // 
            // windowsVersionLabel
            // 
            this.windowsVersionLabel.AutoSize = true;
            this.windowsVersionLabel.Enabled = false;
            this.windowsVersionLabel.Location = new System.Drawing.Point(172, 43);
            this.windowsVersionLabel.Name = "windowsVersionLabel";
            this.windowsVersionLabel.Size = new System.Drawing.Size(88, 13);
            this.windowsVersionLabel.TabIndex = 6;
            this.windowsVersionLabel.Text = "Windows version";
            this.windowsVersionLabel.Visible = false;
            // 
            // windowsVersionCombobox
            // 
            this.windowsVersionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowsVersionCombobox.Enabled = false;
            this.windowsVersionCombobox.FormattingEnabled = true;
            this.windowsVersionCombobox.Location = new System.Drawing.Point(173, 59);
            this.windowsVersionCombobox.Name = "windowsVersionCombobox";
            this.windowsVersionCombobox.Size = new System.Drawing.Size(121, 21);
            this.windowsVersionCombobox.TabIndex = 1;
            this.windowsVersionCombobox.Visible = false;
            this.windowsVersionCombobox.SelectedIndexChanged += new System.EventHandler(this.windowsVersionCombobox_SelectedIndexChanged);
            // 
            // appName
            // 
            this.appName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.appName.HeaderText = "App name";
            this.appName.Name = "appName";
            this.appName.Width = 80;
            // 
            // appLocation
            // 
            this.appLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.appLocation.HeaderText = "App location";
            this.appLocation.Name = "appLocation";
            this.appLocation.Width = 91;
            // 
            // changeDefaultAppGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.windowsVersionCombobox);
            this.Controls.Add(this.windowsVersionLabel);
            this.Controls.Add(this.deleteCurrentGroupButton);
            this.Controls.Add(this.addNewGroupButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.defaultAppGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appGroupSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "changeDefaultAppGroups";
            this.Text = "Default App Groups";
            this.Load += new System.EventHandler(this.changeDefaultAppGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.defaultAppGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox appGroupSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView defaultAppGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addNewGroupButton;
        private System.Windows.Forms.Button deleteCurrentGroupButton;
        private System.Windows.Forms.Label windowsVersionLabel;
        private System.Windows.Forms.ComboBox windowsVersionCombobox;
        private System.Windows.Forms.DataGridViewTextBoxColumn appName;
        private System.Windows.Forms.DataGridViewTextBoxColumn appLocation;
    }
}