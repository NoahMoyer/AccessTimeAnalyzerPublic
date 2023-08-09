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
    public partial class sqlConnectionError : Form
    {
        public string SqlServer;
        public sqlConnectionError()
        {
            InitializeComponent();
        }

        private void confirmServerButton_Click(object sender, EventArgs e)
        {
            setServer();
            this.Close();
        }

        public void setServer()
        {
            SqlServer = sqlServerTextbox.Text;
        }
    }
}
