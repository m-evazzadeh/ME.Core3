using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Session10.Consumer.WebMVC.Services
{
    public class DurationAction
    {
        public TimeSpan duration
        {
            get
            {
                return sw.Elapsed;
            }
        }
        Stopwatch sw;
        private void Start()
        {
            sw = new Stopwatch();
            sw.Start();
        }
        private void Stop()
        {
            sw.Stop();
        }

        public DurationAction()
        {
            Start();
        }

        ~DurationAction()
        {
            Stop();
        }
    }
}
