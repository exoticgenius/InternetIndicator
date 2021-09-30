using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EGO.NetIndicator
{
    public partial class main : Form
    {
        private readonly Core core;

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
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHost.Text))
                core.SetHost(txtHost.Text);
        }
    }
}
