using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Repository.Extensions
{
    public static class CollectionExtensions
    {

        public static void ForEach_<T>(this IEnumerable<T> list, Action<T> action)
        {
            list.ToList().ForEach(action);
        }

        public static IReadOnlyList<T> ToReadonlyList<T>(this IEnumerable<T> list)
        {
            return list.ToImmutableList();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
