using Microsoft.VisualBasic.Logging;
using System.Diagnostics;
using System.Net;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using System.Net.Http;
using System.IO.Pipes;

namespace updater
{
    /// <summary>
    /// This class runs an exe that is designed to download an Microsoft installer (msi file type) and install it silently.
    /// Currently this class is set up to download and install the newest version of the Access Time Anaylyzer from the following github link:
    /// https://github.com/NoahMoyer/AccessTimeAnalyzerPublic/releases/latest/download/App.Access.time.analyzer.installer.msi
    /// 
    /// Visit the following link to learn more about this program:
    /// https://github.com/NoahMoyer/AccessTimeAnalyzerPublic
    /// 
    /// The following pre conditions are expcted:
    /// - Program is being run on a 64 bit windows machine
    /// - This program is only being launched if an outdated install is detected from the main Access Time Analyzer executable
    /// - This program MUST be run as an administrator
    /// </summary>
    public partial class UpdaterForm : Form
    {
        //Begin logging info
        string logFile = "log.txt";
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        //End logging info

        //path to main exe. This is used to re-launch the main program after the update is comlete.
        string mainExe = @"C:\Program Files\Access Time Analyzer\Access time analyzer.exe";
        public UpdaterForm()
        {
            InitializeComponent();

            //Begin logging info
            File.WriteAllTextAsync(logFile, "");
            log("Initializing form");
            //End logging info

            //load form
            //Without this function the update process would not start.
            this.Shown += new EventHandler(Form1_Shown);
        }

        /// <summary>
        /// Function to standardize logging data format.
        /// </summary>
        /// <param name="logData"></param>
        void log(string logData)
        {
            File.AppendAllTextAsync(logFile, "[" + DateTime.Now + "] " + "[User name: " + userName + "] Log: " + logData + "\n");
        }

        /// <summary>
        /// Reset UI back to a default state.
        /// </summary>
        /// <param name="lable"></param>
        void resetUI(string lable)
        {
            //set cursor back to default
            Application.UseWaitCursor = false;
            //rest UI
            statusLable.Text = lable;
            progressBar.Value = 0;
            retryButton.Visible = true;
            okButton.Visible = true;
            releaseNotesLink.Visible = true;
        }
        void resetUI(string lable, int progressValue)
        {
            //set cursor back to default
            Application.UseWaitCursor = false;
            //rest UI
            statusLable.Text = lable;
            progressBar.Value = progressValue;
            retryButton.Visible = true;
            okButton.Visible = true;
            releaseNotesLink.Visible = true;
        }
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            
        }

        /// <summary>
        /// Function to launch install process automatically after the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_Shown(Object sender, EventArgs e)
        {
            try
            {
                //Begin logging info
                log("Loading form and initializing variables");
                //End Logginng info

                //variables
                string installerPath = @"C:\programdata\Access time analyzer\";
                DirectoryInfo installerDirectory = Directory.CreateDirectory(installerPath);
                string installerName = "Access.time.analyzer.installer.msi";
                string msiDownloadLink = "https://github.com/NoahMoyer/AccessTimeAnalyzerPublic/releases/latest/download/App.Access.time.analyzer.installer.msi";
                okButton.Text = "OK";
                okButton.Visible = false;
                releaseNotesLink.Visible = false;

                

                statusLable.Text = "Killing main process";
                progressBar.Value = 10;

                try
                {
                    //Begin logging info
                    log("Killing main process");
                    //End logging info

                    //kill main exe
                    foreach (var mainProcess in Process.GetProcessesByName("Access Time Analyzer"))
                    {
                        mainProcess.Kill();
                    }
                    progressBar.Value = 15;
                }
                catch (Exception Error)
                {
                    //Begin logging info
                    log("Failed to stop main process. Exiting program. Cath error:\n" + Error);
                    //End logging info
                    MessageBox.Show("Failed to stop main process. Please try again after application closes.\n\n" + Error, "\n\nPlease contact your system administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Kill current process
                    Process.GetCurrentProcess().Kill();
                }

                //Begin logging info
                log("Main process succesfully stopped");
                //End logging info

                try
                {
                    //Begin logging info
                    log("Downloading installer");
                    //End logging info
                    statusLable.Text = "Downloading insatller";

                    progressBar.Value = 25;
                    //launch download process
                    Task download = Task.Run(() => downloadFiles(msiDownloadLink, installerPath, installerName));
                    download.Wait();
                    progressBar.Value = 50;
                }
                catch (Exception DownloadError)
                {
                    //Begin logging info
                    log("Failed to download update. Cath error:\n " + DownloadError);
                    //End logging info

                    MessageBox.Show("Failed to download update.\n\n" + DownloadError, "\n\nPlease contact your system administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    resetUI("Failed to download update");

                    return;
                }

                try
                {
                    //Begin logging info
                    log("Installing MSI file");
                    //End logging info

                    statusLable.Text = "Installing update";

                    int installStatus = installProgram(installerPath, installerName);

                    if (installStatus != 0)
                    {
                        resetUI("Failed to install update");
                        return;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        progressBar.Value = progressBar.Value + 2;
                        System.Threading.Thread.Sleep(500);
                    }

                    //Begin logging info
                    log("Deleting temp files");
                    //End logging info
                    //delete directory and installer
                    installerDirectory.Delete(true);
                }
                catch (Exception Error)
                {
                    //Begin logging info
                    log("Failed to install update. Cath error:\n " + Error);
                    //End logging info

                    MessageBox.Show("Failed to install update.\n\n" + Error, "\n\nPlease contact your system administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetUI("Failed to install update");
                    return;
                }

                //Begin logging info
                log("Update installed successfully");
                //End logging info                
                
                System.Threading.Thread.Sleep(5000);

                resetUI("Update installed successfully", 100);
            }
            catch (Exception Error)
            {
                //Begin logging info
                log("Unhandeled exception occured. Cath error:\n " + Error);
                //End logging info

                MessageBox.Show("Unknown error. Please contact your system administrator.\n\n" + Error, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetUI("Unknown error");
                return;
            }
        }

        /// <summary>
        /// Functions to download the installer file from github to a path passed into the function as a string.
        /// Funciton downloadFiles, GetFileStream, and SaveStream are required to download the file.
        /// </summary>
        /// <param name="installerPath"></param>
        /// <param name="installerName"></param>
        async Task downloadFiles(string sourceFile, string destinationFolder, string destinationFileName)
        {
            Stream fileStream = await GetFileStream(sourceFile);

            if (fileStream != Stream.Null)
            {
                await SaveStream(fileStream, destinationFolder, destinationFileName);
            }
        }

        async Task<Stream> GetFileStream(string fileUrl)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                Stream fileStream = await httpClient.GetStreamAsync(fileUrl);
                return fileStream;
            }
            catch (Exception ex)
            {
                log("Unhandeled exception occured. Cath error:\n " + ex);
                return Stream.Null;
            }
        }

        async Task SaveStream(Stream fileStream, string destinationFolder, string destinationFileName)
        {
            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            string path = Path.Combine(destinationFolder, destinationFileName);

            using (FileStream outputFileStream = new FileStream(path, FileMode.CreateNew))
            {
                await fileStream.CopyToAsync(outputFileStream);
            }
        }
        /// End of download file functions.
        ///
        ///



        /// <summary>
        /// Function to launch an installer based on a path passed into the function.
        /// Installer name is also passed into the function
        /// </summary>
        /// <param name="installerPath"></param>
        /// <param name="installerName"></param>
        int installProgram(string installerPath, string installerName)
        {
            try
            {
                Process installProcess = new Process();
                installProcess.StartInfo.FileName = "msiexec";
                installProcess.StartInfo.WorkingDirectory = installerPath;
                installProcess.StartInfo.Arguments = "/i " + installerName + " /q";
                installProcess.StartInfo.Verb = "runas";
                installProcess.Start();

                //string processStandardOutput = installProcess.StandardOutput.ReadToEnd();
                //string processStandardError = installProcess.StandardError.ReadToEnd();

                // Check both strings for !IsNullOrEmpty and log something of interest

                installProcess.WaitForExit();
                int exitCode = 0;
                exitCode = installProcess.ExitCode;

                // If ExitCode != 0, log the StandardError output...
                if (exitCode != 0)
                {
                    throw new InvalidOperationException("Install error. MSI installer returned error code: " + exitCode);
                }

                return exitCode;

            }
            catch (InvalidOperationException Error)
            {
                //Begin logging info
                log("Install function failed. Cath error:\n " + Error);
                //End logging info

                MessageBox.Show("Install function failed. Please contact your system administrator. Function returned the following error: \n\n" + Error, "\n\nInstall Function Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private void progressBar_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Function to launch the main exe and close the current exe when the OK button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Begin logging info
                log("User clicked OK button.");
                //End logging info

                //start main exe
                Process.Start("");
                System.Threading.Thread.Sleep(3000);
                //kill current exe
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception Error)
            {
                //Begin logging info
                log("Failed to start main process. Cath error:\n " + Error);
                //End logging info

                MessageBox.Show("Failed to start main process. Please contact your system administrator. Closing process.\n\n" + Error, "\n\nMain Process execution failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

        }
        /// <summary>
        /// Function to open the latest release notes on Github when the releaseNotesLink is clicked.
        /// This will open the link in the computers default browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void releaseNotesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //Begin logging info
                log("User clicked release notes link.");
                //End logging info

                string url = "https://github.com/NoahMoyer/AccessTimeAnalyzer/releases/latest";
                Process urlProcess = new Process();
                urlProcess.StartInfo.FileName = url;
                urlProcess.StartInfo.UseShellExecute = true;
                urlProcess.Start();
            }
            catch (Exception Error)
            {
                //Begin logging info
                log("Failed to open release notes. Cath error:\n " + Error);
                //End logging info

                MessageBox.Show("Failed to open link. Please contact your system administrator.\n\n" + Error, "\n\nRelease notes execution failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Rety button to restart update app. Will only become visible if the update fails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retryButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Begin logging info
                log("User clicked retry button.");
                //End logging info

                Process.Start(mainExe);
                Application.Restart();
                Environment.Exit(0);
                return;
            }
            catch (Exception Error)
            {
                //Begin logging info
                log("Failed to restart update executable. Cath error:\n " + Error);
                //End logging info

                MessageBox.Show("Failed to restart process. Please contact your system administrator.\n\n" + Error, "\n\nRetry execution failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}