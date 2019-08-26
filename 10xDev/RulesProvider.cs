using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using _10xDev.Rules;

namespace _10xDev
{
    public class RulesProvider : IRuleProvider
    {
        private readonly IFactsRepository _factsRepository;
        public RulesProvider(IFactsRepository factsRepository)
        {
            _factsRepository = factsRepository;
        }

        public IEnumerable<ISortingRule> GetRules()
        {
            var facts = _factsRepository.GetFacts();

            var ruleTypes = Assembly.GetCallingAssembly()
                .GetExportedTypes()
                .Where(t => Attribute.IsDefined(t, typeof(RuleAttribute)));

            return ruleTypes.SelectMany(ruleType =>
                Regex.Matches(facts, ruleType.GetCustomAttribute<RuleAttribute>().Pattern)
                    .Select(match => ActivateRule(ruleType, match)));
        }

        private static ISortingRule ActivateRule(Type ruleType, Match regexMatch)
        {
            const int groupMatchingWhole = 1;
            var args = regexMatch.Groups.Skip(groupMatchingWhole).Select(g => (object) g.Value).ToArray();
            return (ISortingRule) Activator.CreateInstance(ruleType, args);
        }
    }
}
