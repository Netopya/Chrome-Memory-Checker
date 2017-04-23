using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeMemoryChecker
{
    enum ProcessState
    {
        Opening,
        Running,
        Closing,
        Closed
    }

    // A class to hold
    // a found chrome process
    class ChromeProcess
    {

        Process chromeProcess;
        ListView parentListView;
        ListViewItem listItem;
        public ProcessState state { get; private set; }

        public ChromeProcess(Process chromeProcess, int imageIndex, ListView parentListView)
        {
            this.chromeProcess = chromeProcess;
            this.parentListView = parentListView;

            listItem = new ListViewItem(new[] { "",
                chromeProcess.MainModule.FileVersionInfo.FileDescription,
                chromeProcess.ProcessName,
                string.Format("{0:0.000} Mb", chromeProcess.PrivateMemorySize64 / 1024.0 / 1024.0)
            }, imageIndex);

            // Change color to green for opening processes
            listItem.BackColor = Color.LimeGreen;
            state = ProcessState.Opening;

            parentListView.Items.Add(listItem);
        }

        public void Update()
        {
            // If the process has closed, set the list item to red, then remove it
            if(chromeProcess.HasExited)
            {
                if (state == ProcessState.Closing)
                {
                    parentListView.Items.Remove(listItem);
                    state = ProcessState.Closed;
                }
                else
                {
                    listItem.BackColor = Color.Red;
                    state = ProcessState.Closing;
                }
            }
            else
            {
                if(state == ProcessState.Opening)
                {
                    state = ProcessState.Running;
                    listItem.BackColor = Color.White;
                }

                // Update the memory count

                chromeProcess.Refresh();

                listItem.SubItems[3].Text = string.Format("{0:0.000} Mb", chromeProcess.PrivateMemorySize64 / 1024.0 / 1024.0);
            }
        }

        // Check to see if this holder matches a process
        public bool EqualsProcess(Process process)
        {
            return chromeProcess.Id == process.Id;
        }
    }
}
