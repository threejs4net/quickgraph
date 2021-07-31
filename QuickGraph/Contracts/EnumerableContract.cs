using System;
using System.Collections.Generic;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif
using System.Diagnostics;
using System.Linq;

namespace QuickGraph
{
    public static class EnumerableContract
    {
#if CTR
        [Pure]
#endif

        public static bool ElementsNotNull<T>(IEnumerable<T> elements)
        {
#if CTR
            Contract.Requires(elements != null);
#endif
#if DEBUG

            return Enumerable.All(elements, e => e != null);
#else
            return true;
#endif
        }

#if CTR
        [Pure]
#endif

        public static bool All(int lowerBound, int exclusiveUpperBound, Func<int, bool> predicate)
        {
          for (int i = lowerBound; i < exclusiveUpperBound; i++)
          {
            if (!predicate(i)) return false;
          }
          return true;
        }
    }
}
