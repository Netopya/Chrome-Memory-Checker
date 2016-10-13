using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChromeMemoryChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var process = Process.GetProcesses();
            var chrome = process.Where(x => x.ProcessName.Contains("chrome"));

            //Console.WriteLine(string.Join(System.Environment.NewLine, chrome.Select(x => x.ProcessName)));

            var mems = chrome.Select(x => x.PrivateMemorySize64);
            long memb = mems.Aggregate((long)0, (x, y) => x + y);
            double memkb = ((double)memb) / (double)1024.0;
            double memgb = memkb / 1024.0 / 1024.0;
            //Console.WriteLine(memgb.ToString());
            
            lblTotal.Text = string.Format("Total usage in Gb: {0:0.00}Gb over {1} processes", memgb, chrome.Count());

            

            lstvMain.Items.AddRange(chrome.Select(x => new ListViewItem(new[] { x.ProcessName, string.Format("{0:0.000}", x.PrivateMemorySize64 / 1024.0 / 1024.0)})).ToArray());
        }
    }
}
