using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace AGSOutOfOfficeService
{
    public partial class Service1 : ServiceBase
    {
        private EventLog eventLog1;

        public Service1()
        {
            InitializeComponent();
            eventLog1 = EventLog;
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("AGSOutOfOfficeService Start");
            backgroundWorker1.RunWorkerAsync();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("AGSOutOfOfficeService Stop");
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            eventLog1.WriteEntry("AGSOooSrv Background Worker");
            while(!backgroundWorker1.CancellationPending)
            {
                Thread.Sleep(5000);
            }

            eventLog1.WriteEntry("AGSOooSrv Background Worker Cancel");
            e.Cancel = true;
        }
    }
}
