namespace Access_Time_Analyzer
{
    partial class sqlConnectionError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlConnectionError));
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.confirmServerButton = new System.Windows.Forms.Button();
            this.sqlServerTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(87, 21);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(93, 13);
            this.serverNameLabel.TabIndex = 0;
            this.serverNameLabel.Text = "Enter server name";
            // 
            // confirmServerButton
            // 
            this.confirmServerButton.Location = new System.Drawing.Point(91, 63);
            this.confirmServerButton.Name = "confirmServerButton";
            this.confirmServerButton.Size = new System.Drawing.Size(86, 23);
            this.confirmServerButton.TabIndex = 1;
            this.confirmServerButton.Text = "Confirm server";
            this.confirmServerButton.UseVisualStyleBackColor = true;
            this.confirmServerButton.Click += new System.EventHandler(this.confirmServerButton_Click);
            // 
            // sqlServerTextbox
            // 
            this.sqlServerTextbox.Location = new System.Drawing.Point(84, 37);
            this.sqlServerTextbox.Name = "sqlServerTextbox";
            this.sqlServerTextbox.Size = new System.Drawing.Size(100, 20);
            this.sqlServerTextbox.TabIndex = 2;
            // 
            // sqlConnectionError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 113);
            this.Controls.Add(this.sqlServerTextbox);
            this.Controls.Add(this.confirmServerButton);
            this.Controls.Add(this.serverNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sqlConnectionError";
            this.Text = "SQL Connection error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.Button confirmServerButton;
        private System.Windows.Forms.TextBox sqlServerTextbox;
    }
}