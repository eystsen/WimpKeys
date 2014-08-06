using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WimpKeys
{
    public interface IHotKeyManager
    {
        void Bind(List<KeyCommand> keyCommands);
    }

    public class HotKeyManager : NativeWindow, IDisposable, IHotKeyManager
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        private List<KeyCommand> _keyCommands;

        public HotKeyManager()
        {
            CreateHandle(new CreateParams());
        }

        public void Bind(List<KeyCommand> keyCommands)
        {
            _keyCommands = keyCommands;

            foreach (KeyCommand command in _keyCommands)
            {
                InternalRegisterHotKey(this.Handle, command.Id, command.Modifiers, command.Keys);
            }
        }

        protected virtual void InternalRegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc)
        {
            RegisterHotKey(this.Handle, id, fsModifiers, vlc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == ModifierKeys.WM_HOTKEY)
                HandleKeyPress(m.WParam.ToInt32());
            base.WndProc(ref m);
        }

        private void HandleKeyPress(int id)
        {
            KeyCommand command = _keyCommands.Find(x => x.Id == id);

            if (command != null)
                command.Execute();
        }


        public void Dispose()
        {
            DestroyHandle();
        }


    }
}