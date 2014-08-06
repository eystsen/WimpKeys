using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WimpKeys.Properties;

namespace WimpTray
{
    class WimpTrayProgram : IDisposable
    {
        private const string Title = "Wimp Global Hotkeys";
        private NotifyIcon wimpIcon;
        private WimpControl wimpControl;

        public WimpTrayProgram()
        {
            wimpIcon = new NotifyIcon();
            wimpControl = new WimpControl();
            
        }

        public void Show()
        {
            wimpIcon.Icon = Resources.trayicon;
            wimpIcon.MouseClick += OnMouseClick;
            
            wimpIcon.Text = Title;
            wimpIcon.Visible = true;

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            var item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += (sender, args) => Application.Exit();
            contextMenu.Items.Add(item);
            wimpIcon.ContextMenuStrip = contextMenu;

            //RegisterHotKey(IntPtr.Zero, this.GetType().GetHashCode(), 0x0000, 0x42);//Set hotkey as 'b'

        }

        private void OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                wimpIcon.BalloonTipTitle = Title;
                wimpIcon.BalloonTipText = "CTRL+ALT+HOME play/pause\nCTRL+ALT+PGDWN next\nCTRL+ALT+PGUP previous";
                wimpIcon.ShowBalloonTip(3);
            }
        }


        public void Dispose()
        {
            wimpIcon.Dispose();
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);


    }
}
