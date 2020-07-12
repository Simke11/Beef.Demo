using Beef.Database.Core;
using Beef.Test.NUnit;
using NUnit.Framework;
using System.Reflection;
using System.Threading.Tasks;
using Beef.Demo.Api;

namespace Beef.Demo.Test
{
    [SetUpFixture]
    public class FixtureSetUp
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestSetUp.RegisterSetUp(async (count, _) =>
            {
                return await DatabaseExecutor.RunAsync(
                    count == 0 ? DatabaseExecutorCommand.ResetAndDatabase : DatabaseExecutorCommand.ResetAndData, 
                    AgentTester.Configuration["ConnectionStrings:Database"], useBeefDbo: true,
                    typeof(Database.Program).Assembly, Assembly.GetExecutingAssembly()).ConfigureAwait(false) == 0;
            });

            AgentTester.TestServerStart<Startup>("Demo");
            AgentTester.DefaultExpectNoEvents = true;
        }
    }
}