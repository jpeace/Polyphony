using StoryTeller.Engine;

namespace Polyphony.AcceptanceTests.Grammars
{
    public class ConsoleFixture : Fixture
    {
        public ConsoleFixture()
        {
            this["OpenUrl"] = Do<string, IBrowserDriver>("Open the browser to {url}", (url, driver) =>
                                                                                          {
                                                                                            driver.Start();
                                                                                              driver.OpenUrl(url);
                                                                                          });
        }
    }
}