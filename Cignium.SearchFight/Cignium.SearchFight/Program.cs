using System;
using System.Linq;
using System.Threading.Tasks;
using Cignium.SearchFight.Core;

namespace Cignium.SearchFight
{
    class MainClass
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("In order to start SearchFight, " +
                    "write some terms in the command line.");
                return;
            }

            MainFireSearchFightAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainFireSearchFightAsync(string[] args)
        {
            await SearchFightCore.StartAsync(args.ToList());
            SearchFightCore.Reports.ForEach(report => Console.WriteLine(report));
        }
    }
}
