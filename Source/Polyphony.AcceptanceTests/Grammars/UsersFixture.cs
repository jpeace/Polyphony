using StoryTeller.Engine;

namespace Polyphony.AcceptanceTests.Grammars
{
    public class UsersFixture : Fixture
    {
        public UsersFixture()
        {
            this["MakeSureThatUserIsListed"] = Do<string, ITestContext>("Make sure that {firstName} is listed",
                                                                        (firstName, ctx) =>
                                                                            {
                                                                                var driver =
                                                                                    ctx.Retrieve<IBrowserDriver>();
                                                                                if(!driver.IsTextPresent("<span>" + firstName + "</span>"))
                                                                                {
                                                                                    ctx.IncrementWrongs();
                                                                                }
                                                                                driver.Stop();
                                                                            });
        }
    }
    
}