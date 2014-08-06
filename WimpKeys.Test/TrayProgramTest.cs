using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FakeItEasy;
using NUnit.Framework;
using WimpTray;

namespace WimpKeys.Test
{
    [TestFixture]
    public class TrayProgramTest
    {
        [Test]
        public void MouseClick_MouseButtonLeft_ShouldCallShowBalloonTip()
        {
            TrayProgram trayProgram = new TrayProgram(A.Fake<IWimpControl>());
            INotifyIconFacade fakeNotifyIconFacade = A.Fake<INotifyIconFacade>();
            trayProgram.WimpIcon = fakeNotifyIconFacade;
            MouseEventArgs mouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            trayProgram.OnMouseClick(null, mouseEventArgs);

            A.CallTo(() => fakeNotifyIconFacade.ShowBalloonTip(A<int>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void Dispose_Method_ShouldCallDisposeOnNotifyIcon()
        {
            TrayProgram trayProgram = new TrayProgram(A.Fake<IWimpControl>());
            INotifyIconFacade fakeNotifyIconFacade = A.Fake<INotifyIconFacade>();
            trayProgram.WimpIcon = fakeNotifyIconFacade;

            trayProgram.Dispose();

            A.CallTo(() => fakeNotifyIconFacade.Dispose()).MustHaveHappened();
        }


        [Test]
        public void MouseClick_MouseButtonLeft_ShouldSetBalloonTipText()
        {
            TrayProgram trayProgram = new TrayProgram(A.Fake<IWimpControl>());
            trayProgram.WimpIcon = A.Fake<INotifyIconFacade>();
            MouseEventArgs mouseEventArgs = new MouseEventArgs(MouseButtons.Left,1,0,0,0);

            trayProgram.OnMouseClick(null, mouseEventArgs);

            Assert.IsNotNullOrEmpty(trayProgram.WimpIcon.BalloonTipText);
        }

        [Test]
        public void AssignHotKeys_Method_ShouldAddAtLeastOneHotKey()
        {
            TrayProgram trayProgram = new TrayProgram(A.Fake<IWimpControl>());
            IHotKeyColletion fakeHotKeyColletion = A.Fake<IHotKeyColletion>();

            trayProgram.AssignHotKeys(fakeHotKeyColletion, A.Fake<IHotKeyManager>());

            A.CallTo(() => fakeHotKeyColletion.AddHotKey(A<int>.Ignored, A<int>.Ignored, A<Action>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        public void AssignHotKeys_Method_ShouldCallBindOnManager()
        {
            TrayProgram trayProgram = new TrayProgram(A.Fake<IWimpControl>());
            IHotKeyManager fakeHotKeyManager = A.Fake<IHotKeyManager>();

            trayProgram.AssignHotKeys(A.Fake<IHotKeyColletion>(), fakeHotKeyManager);

            A.CallTo(() => fakeHotKeyManager.Bind(A<List<KeyCommand>>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        public void Run_Method_ShouldCreateNotifyIconWithTitle()
        {
            TrayProgram program = new TrayProgram(new WimpControl(new ProcessRunner()));
            program.WimpIcon = A.Fake<INotifyIconFacade>();
            program.Run();

            Assert.IsNotNullOrEmpty(program.WimpIcon.Text);
        }

        [Test]
        public void Run_Method_ShouldCreateContextMenuStrip()
        {
            TrayProgram program = new TrayProgram(new WimpControl(new ProcessRunner()));
            program.WimpIcon = A.Fake<INotifyIconFacade>();

            program.Run();

            Assert.IsNotNull(program.WimpIcon.ContextMenuStrip);
        }

    }
}
