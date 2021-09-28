using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InternetIndicator
{
    public class Tray
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        private readonly NotifyIcon NotifyIcon;
        private readonly Core core;

        public Tray(Core core)
        {
            this.core = core;
            NotifyIcon = new();
            NotifyIcon.MouseClick += Icon_MouseClick;
            SetIcon(MakeSrc());
            NotifyIcon.Visible = true;
        }

        public void SetIcon(Bitmap bmp)
        {
            try
            {
                IntPtr ptr = bmp.GetHicon();
                var old = NotifyIcon.Icon;

                var newi = Icon.FromHandle(ptr);
                NotifyIcon.Icon = newi;
                newi.Dispose();
                bmp.Dispose();
                DestroyIcon(ptr);
                DestroyIcon(newi.Handle);

                if (old is not null)
                    DestroyIcon(old.Handle);
            }
            catch (Exception e)
            {
                Debug.WriteLine("failed: " + e.Message);
            }
        }

        public void RefreshIcon(List<Pinger> ps)
        {
            var src = MakeSrc();
            for (int i = 0; i < ps.Count; i++)
            {
                if (ps[i].Status is CustomIPStatus.Success or CustomIPStatus.None)
                {
                    ps[i].Columns.ForEach(x => SetColumn(x, src));
                }
            }
            SetIcon(src);

            static void SetColumn(int x, Bitmap src)
            {
                for (int i = 2; i < 14; i++)
                {
                    src.SetPixel(x, i, Color.White);
                }
            }
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    new main(core).Show();
                    break;
                case MouseButtons.Right:
                    Application.Exit();
                    break;
            }
        }

        private static Bitmap MakeSrc()
        {
            Bitmap src = new(16, 16);
            for (int i = 2; i < 14; i++)
            {
                for (int j = 2; j < 14; j++)
                {
                    src.SetPixel(i, j, Color.DimGray);
                }
            }
            //src.MakeTransparent(Color.Black);
            //for (int i = 0; i < 16; i++)
            //{
            //    if (i == 0 || i == 1 || i == 14 || i == 15)
            //    {
            //        for (int j = 0; j < 16; j++)
            //        {
            //            src.SetPixel(i, j, Color.White);
            //            src.SetPixel(i, j, Color.White);
            //            src.SetPixel(i, j, Color.White);
            //            src.SetPixel(i, j, Color.White);
            //        }
            //    }
            //    else
            //    {
            //        src.SetPixel(i, 0, Color.White);
            //        src.SetPixel(i, 1, Color.White);
            //        src.SetPixel(i, 14, Color.White);
            //        src.SetPixel(i, 15, Color.White);
            //    }
            //}
            return src;
        }
    }
}
