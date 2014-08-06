using System;
using FakeItEasy;
using NUnit.Framework;
using System.Windows.Forms;


namespace WimpKeys.Test
{
    [TestFixture]
    public class TrayIconBuilderTest
    {
        [Test]
        public void Cosntrutor_DefaultConstructor_ShouldSetTitle()
        {
            INotifyIconFacade fakeNotifyIconFacade = A.Fake<INotifyIconFacade>();

            string title = "TestTitle";
            INotifyIconFacade trayIconBuilder = CreateTrayIconBuilder(fakeNotifyIconFacade, title);

            Assert.AreEqual(fakeNotifyIconFacade.Text, title);
        }

        [Test]
        public void Constructor_DefaultConstructor_ShouldSetIcon()
        {
            INotifyIconFacade fakeNotifyIconFacade = A.Fake<INotifyIconFacade>();

            INotifyIconFacade trayIconBuilder = CreateTrayIconBuilder(fakeNotifyIconFacade, String.Empty);

            var test = fakeNotifyIconFacade.Icon;
            
            Assert.IsNotNull(test);
        }

        [Test]
        public void Constructor_DefaultConstructor_ShouldSetVisible()
        {
            INotifyIconFacade fakeNotifyIconFacade = A.Fake<INotifyIconFacade>();

            INotifyIconFacade trayIconBuilder = CreateTrayIconBuilder(fakeNotifyIconFacade, String.Empty);

            Assert.IsTrue(fakeNotifyIconFacade.Visible);
        }

        private INotifyIconFacade CreateTrayIconBuilder(INotifyIconFacade blankNotifyIcon, string title)
        {
            return new TrayIconBuilder().CreateNotifyIcon(blankNotifyIcon, title);
        }

    }
}
