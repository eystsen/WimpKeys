using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Windows.Forms;
using WimpTray;

namespace WimpKeys
{
    public class TrayProgram : IDisposable
    {
        public INotifyIconFacade WimpIcon { get; set; }
        private IWimpControl _wimpControl;
        private const string Title = "Wimp Global Hotkeys";

        public TrayProgram(IWimpControl wimpControl)
        {
            _wimpControl = wimpControl;
        }

        public void AssignHotKeys(IHotKeyColletion hotKeyColletion, IHotKeyManager hotKeyManager)
        {
            hotKeyColletion.AddHotKey(ModifierKeys.CONTROL + ModifierKeys.ALT, Keys.Home.GetHashCode(), () => _wimpControl.PlayPauseToggle());
            hotKeyColletion.AddHotKey(ModifierKeys.CONTROL + ModifierKeys.ALT, Keys.PageDown.GetHashCode(), () => _wimpControl.Next());
            hotKeyColletion.AddHotKey(ModifierKeys.CONTROL + ModifierKeys.ALT, Keys.PageUp.GetHashCode(), () => _wimpControl.Previous());

            hotKeyManager.Bind(hotKeyColletion.KeyCommands);            
        }

        public void Run()
        {
            WimpIcon = new TrayIconBuilder().CreateNotifyIcon(new NotifyIconFacade(), Title);
            WimpIcon.MouseClick += OnMouseClick;
            WimpIcon.ContextMenuStrip = new ContextMenuStripBuilder().Create(new ContextMenuStrip());
        }

        public void OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                WimpIcon.BalloonTipTitle = Title;
                WimpIcon.BalloonTipText = "CTRL+ALT+HOME play/pause\nCTRL+ALT+PGDWN next\nCTRL+ALT+PGUP previous";
                WimpIcon.ShowBalloonTip(3);
            }
        }

        public void Dispose()
        {
            if (WimpIcon != null)
                WimpIcon.Dispose();
        }
    }
}
