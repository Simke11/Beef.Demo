using Beef.Database.Core;
using System.Threading.Tasks;

namespace Beef.Demo.Database
{
    /// <summary>
    /// Represents the <b>database utilities</b> program (capability).
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main startup.
        /// </summary>
        /// <param name="args">The startup arguments.</param>
        /// <returns>The status code whereby zero indicates success.</returns>
        static Task<int> Main(string[] args)
        {
            return DatabaseConsoleWrapper.Create("Data Source=.;Initial Catalog=Beef.Demo;Integrated Security=True", "Beef", "Demo", useBeefDbo: true).RunAsync(args);
        }
    }
}