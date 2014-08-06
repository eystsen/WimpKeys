using FakeItEasy;
using NUnit.Framework;

namespace WimpKeys.Test
{
    [TestFixture]
    public class ProcessRunnerTest
    {

        [Test]
        public void Execute_ExecuteProgram_ShouldCallProcess()
        {
            IProcessFacade processFacade = A.Fake<IProcessFacade>();
            ProcessRunner processRunner = new ProcessRunner(processFacade, string.Empty);

            processRunner.Execute(string.Empty);

            A.CallTo(() => processFacade.Start()).MustHaveHappened();
        }

        [Test]
        public void Constructor_UsingDefaultContrsuctor_ShouldSetWimpProgramPath()
        {
            ProcessRunner processRunner = new ProcessRunner();

            Assert.IsNotNullOrEmpty(processRunner.WimpFilePath);
        }

    }
}
