using System;
using System.Linq;

namespace _10xDev
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] names = {"Jessie", "Evan", "John", "Sarah", "Matt"};

                var sortService = new SortService(new RulesProvider(new TextFileFactsRepository("facts.txt")));
                var presenter = new Presenter();

                var results = sortService.GetPossibleSorts(names).ToArray();
                Console.WriteLine(presenter.Get10XDeveloper(results));
                Console.WriteLine(presenter.GetLeaderBoard(results));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}
