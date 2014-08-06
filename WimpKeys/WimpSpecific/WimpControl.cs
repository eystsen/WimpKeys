using System;
using System.Diagnostics;
using WimpKeys;

namespace WimpTray
{
    public interface IWimpControl
    {
        void PlayPauseToggle();
        void Next();
        void Previous();
        void StartWimp();
    }

    public class WimpControl : IWimpControl
    {
        private const string PLAYPAUSECOMMAND = "play";
        private const string NEXTCOMMAND = "next";
        private const string PREVIOUSCOMMAND = "previous";
        private IProcessRunner _process;


        public WimpControl(IProcessRunner process)
        {
            _process = process;
        }

        public void PlayPauseToggle()
        {
            ExecuteWimpCommand(PLAYPAUSECOMMAND);
        }

        public void Next()
        {
            ExecuteWimpCommand(NEXTCOMMAND);
        }

        public void Previous()
        {
            ExecuteWimpCommand(PREVIOUSCOMMAND);
        }

        public void StartWimp()
        {
            ExecuteWimpCommand("");
        }

        private void ExecuteWimpCommand(string command)
        {
            _process.Execute(command);
        }
    }
}
