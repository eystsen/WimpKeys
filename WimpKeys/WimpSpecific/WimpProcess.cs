using System.Diagnostics;

namespace WimpKeys
{
    public class WimpProcess
    {
        private const string _wimpProcessName= "wimp";
        private IProcessFacade _processFacade;

        public WimpProcess(IProcessFacade processfacade)
        {
            _processFacade = processfacade;
        }

        public bool IsNotRunning()
        {
            Process[] wimpprocess = _processFacade.GetProcessByName(_wimpProcessName);

            if (wimpprocess.Length > 0)
            {
                return false;
            }

            return true;
        }
    }
}