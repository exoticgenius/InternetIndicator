using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetIndicator
{
    public partial class main : Form
    {
        Core core;
        public main(Core core)
        {
            InitializeComponent();
            btnHead.MouseDown += MouseKeyDown;
            this.core = core;
            txtHost.Text = core.pingers[0].Host;
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public void MouseKeyDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(base.Handle, 161, 2, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHost.Text)) core.SetHost(txtHost.Text);
        }
    }
}
