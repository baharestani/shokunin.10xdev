using System.Collections.Generic;
using _10xDev.Rules;

namespace _10xDev
{
    public interface IRuleProver
    {
        IEnumerable<ISortingRule> GetRules();
    }
}