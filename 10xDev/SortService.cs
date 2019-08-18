using System.Collections.Generic;
using System.Linq;
using _10xDev.Rules;

namespace _10xDev
{
    public class SortService
    {
        private readonly IEnumerable<ISortingRule> _sortingRules;

        public SortService(IEnumerable<ISortingRule> sortingRules)
        {
            _sortingRules = sortingRules;
        }

        public IEnumerable<IEnumerable<string>> GetPossibleSorts(string[] names)
        {
            var permutations = PermutationService.GenerateFor(names);
            return permutations.Where(p => _sortingRules.All(r => r.Matches(p)));
        }


    }
}
