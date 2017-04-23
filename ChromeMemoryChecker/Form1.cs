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
        private Dictionary<string, int> iconMap = new Dictionary<string, int>();
        int IconIndex = 0;
        private List<ChromeProcess> chromeProcesses = new List<ChromeProcess>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateHeader(GetChromeProcesses());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate to the blog
            Process.Start("http://www.netopyaplanet.com/");
        }

        private IEnumerable<Process> GetChromeProcesses()
        {
            var processes = Process.GetProcesses();
            return processes.Where(x => x.ProcessName.Contains("chrome"));
        }

        // Update general process information
        private void UpdateHeader(IEnumerable<Process> chromeProcesses)
        {
            // Calculate total usage in gb
            var mems = chromeProcesses.Select(x => x.PrivateMemorySize64);
            long memb = mems.Aggregate((long)0, (x, y) => x + y);
            double memkb = ((double)memb) / (double)1024.0;
            double memgb = memkb / 1024.0 / 1024.0;

            lblProcessCount.Text = chromeProcesses.Count().ToString();
            lblChromeUsage.Text = string.Format("{0:0.00} Gb", memgb);

            // Set the display icon if there is none found
            if (picIcon.Image == null && chromeProcesses.Any())
            {
                picIcon.Image = Icon.ExtractAssociatedIcon(chromeProcesses.First().MainModule.FileName).ToBitmap();
            }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            var chrome = GetChromeProcesses();

            UpdateHeader(chrome);

            // Update cached processes
            foreach (var chromeProcess in chromeProcesses)
            {
                chromeProcess.Update();
            }

            chromeProcesses.RemoveAll(x => x.state == ProcessState.Closed);

            // Iterate through all found processes
            foreach (var chromep in chrome)
            {
                // Ignore any processes already cached
                if (chromeProcesses.Any(x => x.EqualsProcess(chromep)))
                    continue;

                int imageIndex;
                string chromeIconPath = chromep.MainModule.FileName;

                // Check to see if the program's icon has already been found
                if(iconMap.ContainsKey(chromeIconPath))
                {
                    imageIndex = iconMap[chromeIconPath];
                }
                else
                {
                    iconMap.Add(chromeIconPath, IconIndex);
                    var icon = Icon.ExtractAssociatedIcon(chromeIconPath);
                    imgListProcessIcons.Images.Add(icon);
                    imageIndex = IconIndex;
                    IconIndex++;
                }

                // Create a new process handler for this class
                chromeProcesses.Add(new ChromeProcess(chromep, imageIndex, lstvMain));
            }
        }
    }
}
