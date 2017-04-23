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
            var process = Process.GetProcesses();
            var chrome = process.Where(x => x.ProcessName.Contains("chrome"));

            //Console.WriteLine(string.Join(System.Environment.NewLine, chrome.Select(x => x.ProcessName)));

            var mems = chrome.Select(x => x.PrivateMemorySize64);
            long memb = mems.Aggregate((long)0, (x, y) => x + y);
            double memkb = ((double)memb) / (double)1024.0;
            double memgb = memkb / 1024.0 / 1024.0;
            //Console.WriteLine(memgb.ToString());



            //lblTotal.Text = string.Format("Total usage in Gb: {0:0.00}Gb over {1} processes", memgb, chrome.Count());
            lblProcessCount.Text = chrome.Count().ToString();
            lblChromeUsage.Text = string.Format("{0:0.00} Gb", memgb);


            picIcon.Image = Icon.ExtractAssociatedIcon(chrome.First().MainModule.FileName).ToBitmap();

            //lstvMain.Items.AddRange(chrome.Select(x => new ListViewItem(new[] { "", x.MainModule.FileVersionInfo.FileDescription, x.ProcessName, string.Format("{0:0.000}", x.PrivateMemorySize64 / 1024.0 / 1024.0)}, 0)).ToArray());
            //new ListViewItem(

            //int count = 0;
            //foreach(var chromep in chrome)
            {
                //var icon = Icon.ExtractAssociatedIcon(chromep.MainModule.FileName);
                //imgListProcessIcons.Images.Add(icon);
                //lstvMain.Items.Add(new ListViewItem("", count));
                //var item = lstvMain.Items[count];
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, chromep.MainModule.FileVersionInfo.FileDescription));
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, chromep.ProcessName));
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, string.Format("{0:0.000}", chromep.PrivateMemorySize64 / 1024.0 / 1024.0)));

                //count++;
                //lstvMain.Items[imgListProcessIcons.Images.Count - 1].ImageIndex = imgListProcessIcons.Images.Count - 1;
            }

            //lstvMain.Columns[0].DisplayIndex = 0;
            //lstvMain.Columns[0].Width = 24;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.netopyaplanet.com/");
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            var process = Process.GetProcesses();
            var chrome = process.Where(x => x.ProcessName.Contains("chrome"));

            var mems = chrome.Select(x => x.PrivateMemorySize64);
            long memb = mems.Aggregate((long)0, (x, y) => x + y);
            double memkb = ((double)memb) / (double)1024.0;
            double memgb = memkb / 1024.0 / 1024.0;

            lblProcessCount.Text = chrome.Count().ToString();
            lblChromeUsage.Text = string.Format("{0:0.00} Gb", memgb);

            if(picIcon.Image == null && chrome.Any())
            {
                picIcon.Image = Icon.ExtractAssociatedIcon(chrome.First().MainModule.FileName).ToBitmap();
            }

            foreach(var chromeProcess in chromeProcesses)
            {
                chromeProcess.Update();
            }

            chromeProcesses.RemoveAll(x => x.state == ProcessState.Closed);

            //int count = 0;
            foreach (var chromep in chrome)
            {
                if (chromeProcesses.Any(x => x.EqualsProcess(chromep)))
                    continue;

                int imageIndex;
                string chromeIconPath = chromep.MainModule.FileName;
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

                chromeProcesses.Add(new ChromeProcess(chromep, imageIndex, lstvMain));

                //lstvMain.Items.Add(new ListViewItem("", count));
                //var item = lstvMain.Items[count];
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, chromep.MainModule.FileVersionInfo.FileDescription));
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, chromep.ProcessName));
                //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, string.Format("{0:0.000}", chromep.PrivateMemorySize64 / 1024.0 / 1024.0)));

                //count++;
                //lstvMain.Items[imgListProcessIcons.Images.Count - 1].ImageIndex = imgListProcessIcons.Images.Count - 1;
            }
        }
    }
}
