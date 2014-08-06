using System;
using System.Runtime.InteropServices;

namespace WimpKeys
{
    interface IKeyCommand
    {
        int Id { get; set; }
        int Keys { get; set; }
        int Modifiers { get; set; }
        Action Action { get; set; }
        void Execute();
    }

    public class KeyCommand : IKeyCommand
    {
        public int Id { get; set; }
        public int Keys { get; set; }
        public int Modifiers { get; set; }
        public Action Action { get; set; }

        public KeyCommand(int uniqueKeyCommandId)
        {
            Id = uniqueKeyCommandId;
        }

        public void Execute()
        {
            Action.Invoke();
        }
    }

}
