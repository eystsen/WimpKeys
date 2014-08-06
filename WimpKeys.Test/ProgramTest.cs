using FakeItEasy;
using NUnit.Framework;

namespace WimpKeys.Test
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void ShowSplashScreen_DisplayOf_NeedsToCallShow()
        {
            ISplashForm fakeSplashForm = A.Fake<ISplashForm>();

            Program.ShowSplashScreen(fakeSplashForm,0);

            A.CallTo(() => fakeSplashForm.Show()).MustHaveHappened();
        }

        [Test]
        public void ShowSplashScreen_DisplayOf_NeedsToCallUpdate()
        {
            ISplashForm fakeSplashForm = A.Fake<ISplashForm>();

            Program.ShowSplashScreen(fakeSplashForm, 0);

            A.CallTo(() => fakeSplashForm.Update()).MustHaveHappened();
        }

        [Test]
        public void ShowSplashScreen_DisplayOf_NeedsToCallHide()
        {
            ISplashForm fakeSplashForm = A.Fake<ISplashForm>();

            Program.ShowSplashScreen(fakeSplashForm, 0);

            A.CallTo(() => fakeSplashForm.Hide()).MustHaveHappened();
        }

    }
}
