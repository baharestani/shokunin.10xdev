using System.Collections.Generic;
using System.Linq;

namespace _10xDev.Rules
{
    [Rule(@"\s*(.+) is not.*the best")]
    public class NotTheBestRule : ISortingRule
    {
        private readonly string _name;

        public NotTheBestRule(string name) => _name = name;

        public bool Matches(IEnumerable<string> names) => names.First() != _name;
    }
}
