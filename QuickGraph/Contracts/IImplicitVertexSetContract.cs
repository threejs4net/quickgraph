using System;
using System.Collections.Generic;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Contracts
{
#if CTR
    [ContractClassFor(typeof(IImplicitVertexSet<>))]
#endif
    abstract class IImplicitVertexSetContract<TVertex>
        : IImplicitVertexSet<TVertex>
    {
        [Pure]
        bool IImplicitVertexSet<TVertex>.ContainsVertex(TVertex vertex)
        {
            IImplicitVertexSet<TVertex> ithis = this;
#if CTR
            Contract.Requires(vertex != null);
#endif

            return default(bool);
        }
    }
}
