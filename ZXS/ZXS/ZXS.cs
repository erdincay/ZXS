using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace ZXS
{
    public partial class frmZXS : Form
    {

        BarcodeReader reader;
        ScanDBConnection db; 

        public frmZXS()
        {
            InitializeComponent();
            reader = new BarcodeReader();
            db = new ScanDBConnection();
        }

        private void cmdScan2DB_Click(object sender, EventArgs e)
        {                  
            DirectoryInfo d = new DirectoryInfo(@"C:\IMDaten");

            foreach(FileInfo f in d.GetFiles())
            {
                Job job = new Job(f, reader, db);
                job.Execute();
            }

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
