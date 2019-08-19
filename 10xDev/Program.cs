using System;
using System.Linq;

namespace _10xDev
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Jessie", "Evan", "John", "Sarah", "Matt"};

            var sortService = new SortService(new RulesStore());
            var results = sortService.GetPossibleSorts(names).ToArray();
            var presenter = new Presenter();
            Console.WriteLine(presenter.Get10XDeveloper(results));
            Console.WriteLine(presenter.GetLeaderBoard(results));
        }
    }
}
