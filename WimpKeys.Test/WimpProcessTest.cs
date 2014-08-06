using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using FakeItEasy;
using NUnit.Framework;

namespace WimpKeys.Test
{
    [TestFixture]
    public class WimpProcessTest
    {
        [Test]
        public void IsNotRunning_ProcessIsNotRunning_ReturnsTrue()
        {
            IProcessFacade fakeProcessFacade = A.Fake<IProcessFacade>();
            Process[] emptyProcessList = new Process[0];
            A.CallTo(() => fakeProcessFacade.GetProcessByName(A<string>.Ignored)).Returns(emptyProcessList);
            WimpProcess process = CreateWimpProcess(fakeProcessFacade);

            bool isnotrunning = process.IsNotRunning();

            Assert.IsTrue(isnotrunning);
        }

        [Test]
        public void IsNotRunning_ProcessIsRunning_ReturnsFalse()
        {
            IProcessFacade fakeProcessFacade = A.Fake<IProcessFacade>();
            Process[] oneInProcessList = new Process[1];
            A.CallTo(() => fakeProcessFacade.GetProcessByName(A<string>.Ignored)).Returns(oneInProcessList);
            WimpProcess process = CreateWimpProcess(fakeProcessFacade);

            bool isrunning = process.IsNotRunning();

            Assert.IsFalse(isrunning);
        }

        private static WimpProcess CreateWimpProcess(IProcessFacade fakeProcessFacade)
        {
            return new WimpProcess(fakeProcessFacade);
        }
    }
}
