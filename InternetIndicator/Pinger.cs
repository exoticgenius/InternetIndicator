using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InternetIndicator
{
    public partial class Pinger
    {
        private int timeout;
        private string host;
        private CustomIPStatus status;
        private readonly Ping ping;
        private readonly byte[] buff;

        public string Host
        {
            get { lock (this) return host; }
            set { lock (this) host = value; }
        }

        public int TimeOut
        {
            get { lock (this) return timeout; }
            set { lock (this) timeout = value; }
        }

        public CustomIPStatus Status
        {
            get { lock (this) return status; }
            set { lock (this) status = value; }
        }

        public bool IsFree { get; private set; } = true;
        public List<byte> Columns { get; } = new List<byte>();

        public event OnSuccess OnSuccess;

        public Pinger(string host, int timeOut, params byte[] column)
        {
            Host = host;
            TimeOut = timeOut;
            status = CustomIPStatus.None;
            Columns.AddRange(column);
            ping = new Ping();
            buff = new byte[8];
        }

        public async void Ping()
        {
            if (!IsFree)
                return;

            IsFree = false;

            try
            {
                Debug.WriteLine(TimeOut + " pinging");
                if (string.IsNullOrWhiteSpace(Host))
                {
                    await Task.Delay(TimeOut);
                    return;
                }

                Status = (CustomIPStatus)ping.Send(Host, TimeOut, buff).Status;
                OnSuccess?.Invoke(this);
            }
            catch
            {
                Status = CustomIPStatus.DestinationUnreachable;
            }
            finally
            {
                IsFree = true;
            }
        }
    }
    public delegate void OnSuccess(Pinger sender);
}
