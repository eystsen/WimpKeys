using System;
using System.Drawing;
using System.Windows.Forms;

namespace WimpKeys
{
    public interface INotifyIconFacade
    {
        NotifyIcon notifyIcon { get; set; }
        Icon Icon { get; set; }
        string BalloonTipTitle { get; set; }
        string BalloonTipText { get; set; }
        string Text { get; set; }
        ContextMenuStrip ContextMenuStrip { get; set; }
        bool Visible { get; set; }
        event MouseEventHandler MouseClick;
        void Dispose();
        void ShowBalloonTip(int timeout);
    }

    public class NotifyIconFacade : INotifyIconFacade
    {
        public NotifyIcon notifyIcon { get; set; }

        public NotifyIconFacade()
        {
            notifyIcon = new NotifyIcon();
        }

        public Icon Icon
        {
            get { return notifyIcon.Icon; }
            set { notifyIcon.Icon = value; }
        }

        public string BalloonTipTitle
        {
            get { return notifyIcon.BalloonTipTitle; }
            set { notifyIcon.BalloonTipTitle = value; }
        }

        public string BalloonTipText
        {
            get { return notifyIcon.BalloonTipText; }
            set { notifyIcon.BalloonTipText = value; }
        }

        public string Text
        {
            get { return notifyIcon.Text; }
            set { notifyIcon.Text = value; }
        }

        public ContextMenuStrip ContextMenuStrip
        {
            get { return notifyIcon.ContextMenuStrip; }
            set { notifyIcon.ContextMenuStrip = value; }
        }

        public bool Visible
        {
            get { return notifyIcon.Visible; }
            set { notifyIcon.Visible = value; }
        }

        public event MouseEventHandler MouseClick
        {
            add { notifyIcon.MouseClick += value; }
            remove { notifyIcon.MouseClick -= value; }
        }

        public void Dispose()
        {
            notifyIcon.Dispose();
        }

        public void ShowBalloonTip(int timeout)
        {
            notifyIcon.ShowBalloonTip(timeout);
        }
    }
}