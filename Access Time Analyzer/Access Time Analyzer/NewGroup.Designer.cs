namespace Access_Time_Analyzer
{
    partial class NewGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGroup));
            this.defaultAppGridView = new System.Windows.Forms.DataGridView();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.windowsVersionTextBox = new System.Windows.Forms.TextBox();
            this.appName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.defaultAppGridView)).BeginInit();
            this.SuspendLayout();
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
            this.defaultAppGridView.Location = new System.Drawing.Point(12, 73);
            this.defaultAppGridView.Name = "defaultAppGridView";
            this.defaultAppGridView.Size = new System.Drawing.Size(810, 353);
            this.defaultAppGridView.TabIndex = 2;
            // 
            // groupNameTextBox
            // 
            this.groupNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.groupNameTextBox.Location = new System.Drawing.Point(12, 47);
            this.groupNameTextBox.MaxLength = 2;
            this.groupNameTextBox.Name = "groupNameTextBox";
            this.groupNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.groupNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Group name";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(747, 432);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addGroupButton
            // 
            this.addGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addGroupButton.Location = new System.Drawing.Point(666, 432);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(75, 23);
            this.addGroupButton.TabIndex = 3;
            this.addGroupButton.Text = "Add group";
            this.addGroupButton.UseVisualStyleBackColor = true;
            this.addGroupButton.Click += new System.EventHandler(this.addGroupButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Enabled = false;
            this.versionLabel.Location = new System.Drawing.Point(119, 31);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(152, 13);
            this.versionLabel.TabIndex = 8;
            this.versionLabel.Text = "Windows version for this group";
            this.versionLabel.Visible = false;
            // 
            // windowsVersionTextBox
            // 
            this.windowsVersionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.windowsVersionTextBox.Enabled = false;
            this.windowsVersionTextBox.Location = new System.Drawing.Point(122, 47);
            this.windowsVersionTextBox.MaxLength = 4;
            this.windowsVersionTextBox.Name = "windowsVersionTextBox";
            this.windowsVersionTextBox.Size = new System.Drawing.Size(100, 20);
            this.windowsVersionTextBox.TabIndex = 1;
            this.windowsVersionTextBox.Visible = false;
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
            // NewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.windowsVersionTextBox);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.addGroupButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupNameTextBox);
            this.Controls.Add(this.defaultAppGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "NewGroup";
            this.Text = "Add and edit new group";
            this.Load += new System.EventHandler(this.NewGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.defaultAppGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView defaultAppGridView;
        private System.Windows.Forms.TextBox groupNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox windowsVersionTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn appName;
        private System.Windows.Forms.DataGridViewTextBoxColumn appLocation;
    }
}