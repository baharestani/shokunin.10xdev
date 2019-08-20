using System.Collections.Generic;
using System.Linq;
using _10xDev.Rules;

namespace _10xDev
{
    public class SortService
    {
        private readonly IRuleProvider _ruleProvider;

        public SortService(IRuleProvider ruleProvider)
        {
            _ruleProvider = ruleProvider;
        }

        public IEnumerable<IEnumerable<string>> GetPossibleSorts(string[] names)
        {
            var permutations = PermutationService.GenerateFor(names);
            var rules = _ruleProvider.GetRules();
            return permutations.Where(p => rules.All(r => r.Matches(p)));
        }


    }
}
