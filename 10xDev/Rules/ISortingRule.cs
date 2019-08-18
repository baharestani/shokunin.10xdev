using System.Collections.Generic;

namespace _10xDev.Rules
{
    public interface ISortingRule
    {
        bool Matches(IEnumerable<string> names);
    }
}
