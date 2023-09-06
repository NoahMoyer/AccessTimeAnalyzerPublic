using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccessTimeAnalyzerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

        SQLManager sql = new SQLManager();

        public MainWindow()
        {
            InitializeComponent();
            sql.connectToSqlServer($"Data Source={SQLServer};Initial Catalog=AccessTime;Integrated Security=True;");
            // if(sql.connectToSqlServer($"Data Source={SQLServer};Initial Catalog=AccessTime;Integrated Security=True;"))
            //{
            //    Debug.WriteLine("SQL: Success!");
            //}
            //else
            //{
            //    Debug.WriteLine("SQL: Failed to connect!");
            //}
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
