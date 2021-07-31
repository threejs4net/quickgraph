using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Collections.Contracts
{
#if CTR
    [ContractClassFor(typeof(IDisjointSet<>))]
#endif
    abstract class IDisjointSetContract<T>
        : IDisjointSet<T>
    {
        int IDisjointSet<T>.SetCount
        {
            get
            {
                return default(int);
            }
        }

        int IDisjointSet<T>.ElementCount
        {
            get
            {
                return default(int);
            }
        }

#if CTR
       [ContractInvariantMethod]
#endif
        void ObjectInvariant()
        {
            IDisjointSet<T> ithis = this;
#if CTR
            Contract.Invariant(0 <= ithis.SetCount);
            Contract.Invariant(ithis.SetCount <= ithis.ElementCount);
#endif
        }


        void IDisjointSet<T>.MakeSet(T value)
        {
            IDisjointSet<T> ithis = this;
#if CTR
            Contract.Requires(value != null);
            Contract.Requires(!ithis.Contains(value));
            Contract.Ensures(ithis.Contains(value));
            Contract.Ensures(ithis.SetCount == Contract.OldValue(ithis.SetCount) + 1);
            Contract.Ensures(ithis.ElementCount == Contract.OldValue(ithis.ElementCount) + 1);
#endif
        }

        T IDisjointSet<T>.FindSet(T value)
        {
            IDisjointSet<T> ithis = this;
#if CTR
            Contract.Requires(value != null);
            Contract.Requires(ithis.Contains(value));
#endif
            return default(T);
        }

        bool IDisjointSet<T>.Union(T left, T right)
        {
            IDisjointSet<T> ithis = this;
#if CTR
            Contract.Requires(left != null);
            Contract.Requires(ithis.Contains(left));
            Contract.Requires(right != null);
            Contract.Requires(ithis.Contains(right));
#endif
            return default(bool);
        }

#if CTR
        [Pure]
#endif

        bool IDisjointSet<T>.Contains(T value)
        {
            return default(bool);
        }

        bool IDisjointSet<T>.AreInSameSet(T left, T right)
        {
            IDisjointSet<T> ithis = this;
#if CTR
            Contract.Requires(left != null);
            Contract.Requires(right != null);
            Contract.Requires(ithis.Contains(left));
            Contract.Requires(ithis.Contains(right));
#endif
            return default(bool);
        }
    }
}
