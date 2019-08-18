using System;
using System.Collections.Generic;
using System.Linq;

namespace _10xDev
{
    public static class Extensions
    {
        public static int IndexOf<T>(this IEnumerable<T> @this, T element)
        {
            return Array.IndexOf(@this.ToArray(), element);
        }

        public static string Stringify(this IEnumerable<string> @this)
        {
            return string.Join(',', @this);
        }
    }
}
