using System;
using System.Collections.Generic;

namespace _10xDev.Rules
{
    [Rule(@"\s*(.+) is not directly below or above (.+) as a developer")]
    public class NotNextToRule : ISortingRule
    {
        private readonly string _name1;
        private readonly string _name2;

        public NotNextToRule(string name1, string name2)
        {
            _name1 = name1;
            _name2 = name2;
        }

        public bool Matches(IEnumerable<string> names) => Math.Abs(names.IndexOf(_name1) - names.IndexOf(_name2)) > 1;
    }
}
