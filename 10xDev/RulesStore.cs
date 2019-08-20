using System.Collections.Generic;
using _10xDev.Rules;

namespace _10xDev
{
    public class RulesStore : IRuleProvider
    {
        public IEnumerable<ISortingRule> GetRules()
        {
            return new ISortingRule[]
            {
                new NotTheBestRule("Jessie"),
                new NotTheWorstRule("Evan"),
                new NotTheBestRule("John"),
                new NotTheWorstRule("John"),
                new NotNextToRule("Matt", "John"),
                new NotNextToRule("Evan", "John"),
                new BetterRule("Sarah", "Evan"),
            };
        }
    }
}