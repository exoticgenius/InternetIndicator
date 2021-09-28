using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Windows.Forms;

namespace InternetIndicator
{
    static class Program
    {
        private static Core core;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GCSettings.LatencyMode = GCLatencyMode.LowLatency;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            core = new();
            core.pingers.Add(new("1.1.1.1", 100, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
            core.pingers.Add(new("1.1.1.1", 150, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
            core.pingers.Add(new("1.1.1.1", 200, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
            Pinger p4 = new("1.1.1.1", 300, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            p4.OnSuccess += P4_OnSuccess;
            core.pingers.Add(p4);
            core.pingers.Add(new("1.1.1.1", 400, 2, 3, 4, 5, 6, 7, 8, 9));
            core.pingers.Add(new("1.1.1.1", 500, 2, 3, 4, 5, 6, 7, 8));
            core.pingers.Add(new("1.1.1.1", 650, 2, 3, 4, 5, 6, 7));
            core.pingers.Add(new("1.1.1.1", 900, 2, 3, 4, 5, 6));
            core.pingers.Add(new("1.1.1.1", 1500, 2, 3, 4, 5));
            core.pingers.Add(new("1.1.1.1", 2500, 2, 3, 4));
            core.pingers.Add(new("1.1.1.1", 3750, 2, 3));
            core.pingers.Add(new("1.1.1.1", 5500, 2));

            Application.Run();
        }

        private static void P4_OnSuccess(Pinger sender)
        {
            List<Pinger> ps;

            lock (core)
            {
                ps = core.pingers.Skip(4).ToList();
            }

            ps.ForEach(x => x.Status = CustomIPStatus.None);
            ps.Clear();
        }
    }
}
