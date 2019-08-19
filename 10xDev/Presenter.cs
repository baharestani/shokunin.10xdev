using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10xDev
{
    public class Presenter
    {
        public string Get10XDeveloper(IEnumerable<string>[] results)
        {
            var result = EnsureSingleResult(results);
            return $"The 10X Developer is {result[0]}";
        }

        public string GetLeaderBoard(IEnumerable<string>[] results)
        {
            var result = EnsureSingleResult(results);
            var leaderBoardBuilder = new StringBuilder();
            leaderBoardBuilder.AppendLine("Leader board:");
            for (var i = 0; i < result.Length; i++)
            {
                leaderBoardBuilder.AppendLine($"{i + 1}. {result[i]}");
            }

            return leaderBoardBuilder.ToString();
        }

        private static string[] EnsureSingleResult(IEnumerable<string>[] results)
        {
            return results.Length == 1 ?
                results.Single().ToArray() :
                throw new InvalidOperationException("More than one possible ordering.");
        }
    }
}
