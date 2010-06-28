using NUnit.Framework;
using StoryTeller.Execution;

namespace Polyphony.AcceptanceTests
{
    [TestFixture, Explicit]
    public class Template
    {
        private ProjectTestRunner runner;

        [TestFixtureSetUp]
        public void SetupRunner()
        {
            runner = new ProjectTestRunner(@"C:\Development\Spikes\Polyphony\Source\Polyphony.AcceptanceTests\bin\Debug\Polyphony.xml");
        }

        [Test]
        public void Verifying_Users()
        {
            runner.RunAndAssertTest("Users/Verifying Users");
        }

        [TestFixtureTearDown]
        public void TeardownRunner()
        {
            runner.Dispose();
        }
    }
}