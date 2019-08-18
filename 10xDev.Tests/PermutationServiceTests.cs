using System;
using System.Collections;
using System.Linq;
using Shouldly;
using Xunit;

namespace _10xDev.Tests
{
    public class PermutationServiceTests
    {
        [Fact]
        public void GeneratesPermutationsForGivenNames()
        {
            var items = new[] {"a", "b", "c"};
            var permutations = PermutationService.GenerateFor(items).ToArray();

            permutations.Length.ShouldBe(6);
            permutations.ShouldContain(p => p.SequenceEqual(new[] {"a", "b", "c"}));
            permutations.ShouldContain(p => p.SequenceEqual(new[] {"b", "a", "c"}));
            permutations.ShouldContain(p => p.SequenceEqual(new[] {"c", "a", "b"}));
            permutations.ShouldContain(p => p.SequenceEqual(new[] {"a", "c", "b"}));
            permutations.ShouldContain(p => p.SequenceEqual(new[] {"b", "c", "a"}));
            permutations.ShouldContain(p => p.SequenceEqual(new[] {"c", "b", "a"}));
        }

        [Fact]
        public void GenerateNoResultsWithNoErrorsForEmptyInput()
        {
            var items = new string[0];
            var permutations = PermutationService.GenerateFor(items).ToArray();

            permutations.Length.ShouldBe(0);
        }
    }
}
