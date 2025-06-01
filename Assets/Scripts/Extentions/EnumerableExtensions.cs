using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extentions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> NoNulls<T>(this IEnumerable<T> self) where T : Object => self.Where(element => element);
    }
}