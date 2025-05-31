using System.Collections.Generic;
using System.Linq;

namespace Extentions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> NoNulls<T>(this IEnumerable<T> self) => self.Where(element => element != null);
    }
}