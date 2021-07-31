﻿using System;
using System.Collections.Generic;
#if CTR        
using System.Diagnostics.Contracts;
using QuickGraph.Contracts;
#endif

namespace QuickGraph
{
    /// <summary>
    /// A mutable indirect graph
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
#if CTR        
    [ContractClass(typeof(IMutableUndirectedGraphContract<,>))]
#endif
    public interface IMutableUndirectedGraph<TVertex,TEdge> 
        : IMutableEdgeListGraph<TVertex,TEdge>
        , IMutableVertexSet<TVertex>
        , IUndirectedGraph<TVertex,TEdge>
        , IMutableVertexAndEdgeSet<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        int RemoveAdjacentEdgeIf(TVertex vertex, EdgePredicate<TVertex, TEdge> predicate);
        void ClearAdjacentEdges(TVertex vertex);
    }
}
