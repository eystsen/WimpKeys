using System;
using System.Diagnostics;
using FakeItEasy;
using NUnit.Framework;

namespace WimpKeys
{
    public interface IProcessRunner
    {
        void Execute(string command);
    }

    public class ProcessRunner : IProcessRunner
    {
        public string WimpFilePath { get; set; }
        private IProcessFacade _process;

        public ProcessRunner()
        {
            WimpFilePath = WimpProgramFilePath();
            _process = new ProcessFacade(new Process());
        }

        public ProcessRunner(IProcessFacade processfacade, string filePath)
        {
            WimpFilePath = filePath;
            _process = processfacade;
        }

        private static string WimpProgramFilePath()
        {
            var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            return programFilesPath + @"\wimp\wimp.exe";
        }

        public void Execute(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo {FileName = WimpFilePath, Arguments = command};

            _process.StartInfo = processStartInfo;
            _process.Start();
        }

    }


}
