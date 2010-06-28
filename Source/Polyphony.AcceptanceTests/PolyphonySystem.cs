using System;
using Selenium;
using StoryTeller.Engine;

namespace Polyphony.AcceptanceTests
{
    public class PolyphonySystem : ISystem
    {
        public object Get(Type type)
        {
            throw new NotImplementedException();
        }

        public void RegisterServices(ITestContext context)
        {
            var selenium = new DefaultSelenium("localhost", 4444, @"*firefox C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "http://localhost:60691");
            context.Store<IBrowserDriver>(new SeleniumBrowserDriver(selenium));
        }

        public void SetupEnvironment()
        {
        }

        public void TeardownEnvironment()
        {
        }

        public void Setup()
        {
        }

        public void Teardown()
        {
        }

        public void RegisterFixtures(FixtureRegistry registry)
        {
            registry.AddFixturesFromThisAssembly();
        }
    }
}