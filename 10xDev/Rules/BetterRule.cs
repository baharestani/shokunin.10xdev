using System;
using System.Collections.Generic;
using System.Linq;

namespace _10xDev.Rules
{
    public class BetterRule : ISortingRule
    {
        private readonly string _better;
        private readonly string _worse;

        public BetterRule(string better, string worse)
        {
            _better = better;
            _worse = worse;
        }

        public bool Matches(IEnumerable<string> names)
        {
            var namesArray = names.ToArray();
            return namesArray.IndexOf(_better) < namesArray.IndexOf(_worse);
        }
    }
}
