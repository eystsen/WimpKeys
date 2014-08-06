using System;
using System.Collections.Generic;

namespace WimpKeys
{
    public interface IHotKeyColletion
    {
        List<KeyCommand> KeyCommands { get; set; }
        void AddHotKey(int modifiers, int keys, Action action);
    }

    public class HotKeyColletion : IHotKeyColletion
    {
        private int _uniqueHotKeyId;

        public List<KeyCommand> KeyCommands { get; set; }

        public HotKeyColletion()
        {
            _uniqueHotKeyId = 1;
            KeyCommands = new List<KeyCommand>();
        }

        public void AddHotKey(int modifiers, int keys, Action action)
        {
            KeyCommand command = new KeyCommand(++_uniqueHotKeyId);
            command.Modifiers = modifiers;
            command.Keys = keys;
            command.Action = action;

            KeyCommands.Add(command);
        }
    }
}