using System;
#if CTR
using System.Diagnostics.Contracts;
#endif
using System.Collections.Generic;

namespace QuickGraph.Contracts
{
#if CTR
    [ContractClassFor(typeof(IUndirectedEdge<>))]
#endif
    abstract class IUndirectedEdgeContract<TVertex>
        : IUndirectedEdge<TVertex>
    {
#if CTR
        [ContractInvariantMethod]
#endif
        void IUndirectedEdgeInvariant()
        {
            IUndirectedEdge<TVertex> ithis = this;
#if CTR
            Contract.Invariant(Comparer<TVertex>.Default.Compare(ithis.Source, ithis.Target) <= 0);
#endif
        }

        #region IEdge<TVertex> Members

        public TVertex Source {
          get { throw new NotImplementedException(); }
        }

        public TVertex Target {
          get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
