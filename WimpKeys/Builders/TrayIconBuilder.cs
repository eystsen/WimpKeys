using System;
using System.Windows.Forms;
using WimpKeys.Properties;

namespace WimpKeys
{

    public class TrayIconBuilder
    {
        private INotifyIconFacade _notifyIcon;

        public event MouseEventHandler MouseClick
        {
            add { _notifyIcon.MouseClick += value; }
            remove { _notifyIcon.MouseClick -= value; }
        }

        public INotifyIconFacade CreateNotifyIcon(INotifyIconFacade blankNotifyIcon, string title)
        {
            _notifyIcon = blankNotifyIcon;
            _notifyIcon.Icon = Resources.trayicon;
            _notifyIcon.Text = title;
            _notifyIcon.Visible = true;

            return _notifyIcon;
        }
    }
}