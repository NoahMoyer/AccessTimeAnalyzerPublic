namespace updater
{
    partial class UpdaterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdaterForm));
            statusLable = new Label();
            progressBar = new ProgressBar();
            okButton = new Button();
            releaseNotesLink = new LinkLabel();
            retryButton = new Button();
            SuspendLayout();
            // 
            // statusLable
            // 
            statusLable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusLable.AutoSize = true;
            statusLable.Location = new Point(110, 27);
            statusLable.Name = "statusLable";
            statusLable.Size = new Size(70, 15);
            statusLable.TabIndex = 0;
            statusLable.Text = "Status Lable";
            statusLable.UseWaitCursor = true;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(110, 45);
            progressBar.MarqueeAnimationSpeed = 50;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(182, 23);
            progressBar.TabIndex = 1;
            progressBar.UseWaitCursor = true;
            progressBar.Click += progressBar_Click;
            // 
            // okButton
            // 
            okButton.Location = new Point(331, 80);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.UseWaitCursor = true;
            okButton.Visible = false;
            okButton.Click += okButton_Click;
            // 
            // releaseNotesLink
            // 
            releaseNotesLink.AutoSize = true;
            releaseNotesLink.Location = new Point(12, 88);
            releaseNotesLink.Name = "releaseNotesLink";
            releaseNotesLink.Size = new Size(78, 15);
            releaseNotesLink.TabIndex = 3;
            releaseNotesLink.TabStop = true;
            releaseNotesLink.Text = "Release notes";
            releaseNotesLink.UseWaitCursor = true;
            releaseNotesLink.Visible = false;
            releaseNotesLink.LinkClicked += releaseNotesLink_LinkClicked;
            // 
            // retryButton
            // 
            retryButton.Location = new Point(250, 80);
            retryButton.Name = "retryButton";
            retryButton.Size = new Size(75, 23);
            retryButton.TabIndex = 4;
            retryButton.Text = "Retry";
            retryButton.UseVisualStyleBackColor = true;
            retryButton.UseWaitCursor = true;
            retryButton.Visible = false;
            retryButton.Click += retryButton_Click;
            // 
            // UpdaterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 121);
            Controls.Add(retryButton);
            Controls.Add(releaseNotesLink);
            Controls.Add(okButton);
            Controls.Add(progressBar);
            Controls.Add(statusLable);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(434, 160);
            MinimumSize = new Size(434, 160);
            Name = "UpdaterForm";
            Text = "Access Time Analyser updater";
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusLable;
        private ProgressBar progressBar;
        private Button okButton;
        private LinkLabel releaseNotesLink;
        private Button retryButton;
    }
}