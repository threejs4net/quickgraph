using System;
using System.Collections.Generic;
#if CTR        
using QuickGraph.Contracts;
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if CTR        
    [ContractClass(typeof(IIncidenceGraphContract<,>))]
#endif
    public interface IIncidenceGraph<TVertex, TEdge> 
        : IImplicitGraph<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
        bool ContainsEdge(TVertex source, TVertex target);
        bool TryGetEdges(
            TVertex source,
            TVertex target,
            out IEnumerable<TEdge> edges);
        bool TryGetEdge(
            TVertex source,
            TVertex target,
            out TEdge edge);
    }
}
