using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using WimpTray;

namespace WimpKeys.Test
{
    [TestFixture]
    public class WimpControlTest
    {
        [Test]
        public void PlayPauseToggle_Method_ShouldCallExecuteOnProcess()
        {
            var fakeProcess = A.Fake<IProcessRunner>();
            WimpControl control = CreateWimpControl(fakeProcess, String.Empty);
            
            control.PlayPauseToggle();

            A.CallTo(() => fakeProcess.Execute(A<String>.Ignored)).MustHaveHappened();
        }


        [Test]
        public void Previous_Method_ShouldCallExecuteOnProcess()
        {
            var fakeProcess = A.Fake<IProcessRunner>();
            WimpControl control = CreateWimpControl(fakeProcess, String.Empty);

            control.Previous();

            A.CallTo(() => fakeProcess.Execute(A<String>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void Next_Method_ShouldCallExecuteOnProcess()
        {
            var fakeProcess = A.Fake<IProcessRunner>();
            WimpControl control = CreateWimpControl(fakeProcess, String.Empty);

            control.Next();

            A.CallTo(() => fakeProcess.Execute(A<String>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void StartWimp_Method_ShouldCallExecuteOnProcess()
        {
            var fakeProcess = A.Fake<IProcessRunner>();
            WimpControl control = CreateWimpControl(fakeProcess, String.Empty);

            control.StartWimp();

            A.CallTo(() => fakeProcess.Execute(A<String>.Ignored)).MustHaveHappened();
        }

        private WimpControl CreateWimpControl(IProcessRunner fakeProcess, string filepath)
        {
            return new WimpControl(fakeProcess);
        }

    }
}
