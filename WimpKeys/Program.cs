using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WimpTray;

namespace WimpKeys
{
    public static class Program
    {
        const int SPLASHSCREENVISIBLEMILLISECONDS = 1000;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WimpControl wimpControl = new WimpControl(new ProcessRunner());
            using (TrayProgram trayProgram = new TrayProgram(wimpControl))
            {
                ShowSplashScreen(new SplashForm(), SPLASHSCREENVISIBLEMILLISECONDS);

                wimpControl.StartWimp();
                trayProgram.AssignHotKeys(new HotKeyColletion(), new HotKeyManager());
                trayProgram.Run();

                Application.Run();
            }
        }

        public static void ShowSplashScreen(ISplashForm splashForm, int milliseconds)
        {
            splashForm.Show();
            splashForm.Update();
            Thread.Sleep(milliseconds);
            splashForm.Hide();
        }
    }
}
