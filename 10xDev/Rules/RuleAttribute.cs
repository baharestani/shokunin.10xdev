using System;

namespace _10xDev.Rules
{
    public class RuleAttribute : Attribute
    {
        public string Pattern { get; }

        public RuleAttribute(string pattern)
        {
            Pattern = pattern;
        }
    }
}
