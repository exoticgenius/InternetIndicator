using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGO.NetIndicator
{
    public class Core
    {
        private readonly Task observerTask;
        private readonly Task pingerTask;
        public List<Pinger> pingers = new();
        private readonly Tray tray;

        public Core()
        {
            tray = new(this);
            observerTask = Observer();
            pingerTask = Pinger();
        }

        private async Task Observer()
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

        private async Task Pinger()
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
                    if (ps.Count == 0)
                        continue;

                    bool called = false;
                    for (int i = 0; i < ps.Count; i++)
                    {
                        if (ps[i].Status is CustomIPStatus.Success or CustomIPStatus.None)
                        {
                            called = true;
                            ps[i].Status = CustomIPStatus.None;
                            ps[i].Ping();
                            if (i > 0)
                            {
                                pingFirst += 10 - i;
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
                        ps[^1].Status = CustomIPStatus.None;
                        ps[^1].Ping();
                        ps[^2].Ping();
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
