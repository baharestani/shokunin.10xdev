using System.Collections.Generic;
using System.Linq;

namespace _10xDev.Rules
{
    [Rule(@"\s*(.+) is not.*the worst")]
    public class NotTheWorstRule : ISortingRule
    {
        private readonly string _name;

        public NotTheWorstRule(string name) => _name = name;

        public bool Matches(IEnumerable<string> names) => names.Last() != _name;
    }
}
