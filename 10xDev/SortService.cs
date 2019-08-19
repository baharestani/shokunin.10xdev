using System.Collections.Generic;
using System.Linq;
using _10xDev.Rules;

namespace _10xDev
{
    public class SortService
    {
        private readonly IRuleProver _ruleProver;

        public SortService(IRuleProver ruleProver)
        {
            _ruleProver = ruleProver;
        }

        public IEnumerable<IEnumerable<string>> GetPossibleSorts(string[] names)
        {
            var permutations = PermutationService.GenerateFor(names);
            var rules = _ruleProver.GetRules();
            return permutations.Where(p => rules.All(r => r.Matches(p)));
        }


    }
}
