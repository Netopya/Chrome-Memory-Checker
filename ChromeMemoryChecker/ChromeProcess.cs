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

    class ChromeProcess
    {

        Process chromeProcess;
        ListView parentListView;
        ListViewItem listItem;
        public ProcessState state { get; private set; }
        long oldMemory;

        public ChromeProcess(Process chromeProcess, int imageIndex, ListView parentListView)
        {
            this.chromeProcess = chromeProcess;
            this.parentListView = parentListView;

            listItem = new ListViewItem(new[] { "",
                chromeProcess.MainModule.FileVersionInfo.FileDescription,
                chromeProcess.ProcessName,
                string.Format("{0:0.000} Mb", chromeProcess.WorkingSet64 / 1024.0 / 1024.0)
            }, imageIndex);

            listItem.BackColor = Color.Green;
            state = ProcessState.Opening;

            parentListView.Items.Add(listItem);
        }

        public void Update()
        {
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

                chromeProcess.Refresh();

                //long memory = Process.GetProcessById(chromeProcess.Id).PrivateMemorySize64;
                long memory = chromeProcess.PrivateMemorySize64;

                if (memory != oldMemory)
                    Console.WriteLine("Memory Changed! {2} from {0:0.000} to {1:0.000}", oldMemory / 1024.0 / 1024.0, memory / 1024.0 / 1024.0, chromeProcess.Id);

                oldMemory = memory;

                //listItem.SubItems[3].Text = string.Format("{0:0.00000000} Mb", memory / 1024.0 / 1024.0);

                listItem.SubItems[3].Text = string.Format("Memory Changed! {2} from {0:0.000} to {1:0.000}", oldMemory / 1024.0 / 1024.0, memory / 1024.0 / 1024.0, chromeProcess.Id);
            }
        }

        public bool EqualsProcess(Process process)
        {
            return chromeProcess.Id == process.Id;
        }
    }
}
