using System.Collections.Generic;
using System.Linq;
using _10xDev.Rules;
using Shouldly;
using Xunit;

namespace _10xDev.Tests
{
    public class SortServiceTests
    {
        private readonly string[] _names = {"Jessie", "Evan", "John", "Sarah", "Matt"};
        private readonly IEnumerable<IEnumerable<string>> _possibleResults;

        public SortServiceTests()
        {
            var sortService = new SortService(new RulesStore());
            _possibleResults = sortService.GetPossibleSorts(_names);
        }

        [Fact]
        public void Sorted_names_should_always_contain_all_of_them()
        {
            _possibleResults.ShouldAllBe(p => p.Count() == _names.Length);
            _possibleResults.ShouldAllBe(p=> p.Contains("Jessie"));
            _possibleResults.ShouldAllBe(p=> p.Contains("Evan"));
            _possibleResults.ShouldAllBe(p=> p.Contains("John"));
            _possibleResults.ShouldAllBe(p=> p.Contains("Sarah"));
            _possibleResults.ShouldAllBe(p=> p.Contains("Matt"));
        }

        [Fact]
        public void Jessie_is_not_the_best_developer()
        {
            _possibleResults.ShouldNotContain(p => p.First() == "Jessie");
        }

        [Fact]
        public void Evan_is_not_the_worst_developer()
        {
            _possibleResults.ShouldNotContain(p => p.Last() == "Evan");
        }

        [Fact]
        public void John_is_not_the_best_developer_or_the_worst_developer()
        {
            _possibleResults.ShouldNotContain(p => p.Last() == "John");
            _possibleResults.ShouldNotContain(p => p.First() == "John");
        }

        [Fact]
        public void Sarah_is_a_better_developer_than_Evan()
        {
            _possibleResults.ShouldAllBe(result =>
                result.IndexOf("Sarah") < result.IndexOf("Evan")
            );
        }

        [Fact]
        public void Matt_is_not_directly_below_or_above_John_as_a_developer()
        {
            _possibleResults.ShouldNotContain(result => result.Stringify().Contains("Matt,John"));
            _possibleResults.ShouldNotContain(result => result.Stringify().Contains("John,Matt"));
        }

        [Fact]
        public void John_is_not_directly_below_or_above_Evan_as_a_developer()
        {
            _possibleResults.ShouldNotContain(result => result.Stringify().Contains("John,Evan"));
            _possibleResults.ShouldNotContain(result => result.Stringify().Contains("Evan,John"));
        }

        [Fact]
        public void When_all_rules_apply_there_will_be_one_result()
        {
            _possibleResults.Count().ShouldBe(1);
        }
    }
}
