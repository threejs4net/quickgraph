using System;
using System.Collections.Generic;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Contracts
{
#if CTR
    [ContractClassFor(typeof(IEdge<>))]
#endif
    abstract class IEdgeContract<TVertex>
        : IEdge<TVertex>
    {
#if CTR
        [ContractInvariantMethod]
#endif
        void IEdgeInvariant()
        {
            IEdge<TVertex> ithis = this;
#if CTR
            Contract.Invariant(ithis.Source != null);
            Contract.Invariant(ithis.Target != null);
#endif
        }

        TVertex IEdge<TVertex>.Source
        {
            get
            {
#if CTR
                Contract.Ensures(Contract.Result<TVertex>() != null);
#endif
                return default(TVertex);
            }
        }

        TVertex IEdge<TVertex>.Target
        {
            get
            {
#if CTR
                Contract.Ensures(Contract.Result<TVertex>() != null);
#endif
                return default(TVertex);
            }
        }
    }
}
