using System;
using System.Collections.Generic;
#if CTR
using System.Diagnostics.Contracts;
using QuickGraph.Contracts;
#endif

namespace QuickGraph
{
#if CTR        
    [ContractClass(typeof(IImplicitUndirectedGraphContract<,>))]
#endif
    public interface IImplicitUndirectedGraph<TVertex, TEdge>
        : IImplicitVertexSet<TVertex>
        , IGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
#if CTR        
        [Pure]
#endif
        EdgeEqualityComparer<TVertex, TEdge> EdgeEqualityComparer { get; }

#if CTR        
        [Pure]
#endif
        IEnumerable<TEdge> AdjacentEdges(TVertex v);

#if CTR        
        [Pure]
#endif
        int AdjacentDegree(TVertex v);

#if CTR        
        [Pure]
#endif
        bool IsAdjacentEdgesEmpty(TVertex v);

#if CTR        
        [Pure]
#endif

        TEdge AdjacentEdge(TVertex v, int index);

#if CTR        
        [Pure]
#endif

        bool TryGetEdge(TVertex source, TVertex target, out TEdge edge);

#if CTR        
        [Pure]
#endif

        bool ContainsEdge(TVertex source, TVertex target);
    }
}
