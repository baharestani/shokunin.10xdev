using System.Collections.Generic;
using System.Linq;

namespace _10xDev
{
    public static class PermutationService
    {
        public static IEnumerable<IEnumerable<string>> GenerateFor(string[] items)
        {
            if (items.Length == 1)
                yield return items;

            foreach (var item in items)
            {
                var otherItems = items.Except(new[] {item});
                foreach (var permutation in GenerateFor(otherItems.ToArray()))
                {
                    yield return permutation.Prepend(item);
                }
            }
        }
    }
}
