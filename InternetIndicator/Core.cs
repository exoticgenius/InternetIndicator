using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InternetIndicator
{
    public class Core
    {
        Task observerTask;
        Task pingerTask;
        public List<Pinger> pingers = new List<Pinger>();
        Tray tray;
        public Core()
        {
            tray = new Tray(this);
            observerTask = observer();
            pingerTask = pinger();
        }

        private async Task observer()
        {
            while (true)
            {
                try
                {
                    List<Pinger> ps;
                    lock (pingers)
                    {
                        ps = pingers.ToList();
                    }
                    tray.RefreshIcon(ps);
                }
                finally
                {
                    await Task.Delay(150);

                }
            }
        }
        private async Task pinger()
        {
            List<Pinger> ps;
            int pingFirst = 10;
            while (true)
            {
                lock (pingers)
                {
                    ps = pingers.ToList();
                }
                try
                {
                    if (ps.Count == 0) continue;
                    bool called = false;
                    for (int i = 0; i < ps.Count; i++)
                    {
                        if (ps[i].Status == CustomIPStatus.Success || ps[i].Status == CustomIPStatus.None)
                        {
                            called = true;
                            ps[i].Status = CustomIPStatus.None;
                            ps[i].Ping();
                            if (i > 0)
                            {
                                pingFirst+= 10-i;
                                if (pingFirst <= 5)
                                {
                                    pingFirst = 10;
                                    ps[3].Ping();
                                }
                                ps[i - 1].Ping();
                            }
                            else
                                pingFirst = 10;
                            break;
                        }
                    }
                    if (!called)
                    {
                        pingFirst = 0;
                        ps[ps.Count - 1].Status = CustomIPStatus.None;
                        ps[ps.Count - 1].Ping();
                        ps[ps.Count - 2].Ping();
                    }
                }
                finally
                {
                    ps.Clear();
                    await Task.Delay(500);
                }
            }
        }

        internal void SetHost(string text)
        {
            List<Pinger> ps;
            lock (pingers)
            {
                ps = pingers.ToList();
            }
            ps.ForEach(x => x.Host = text);
            ps.Clear();
        }
    }
}
