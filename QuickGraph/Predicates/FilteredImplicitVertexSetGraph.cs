﻿using System;
using System.Collections.Generic;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Predicates
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public class FilteredImplicitVertexSet<TVertex, TEdge, TGraph> 
        : FilteredGraph<TVertex,TEdge,TGraph>
        , IImplicitVertexSet<TVertex>
        where TEdge : IEdge<TVertex>
        where TGraph : IGraph<TVertex, TEdge>, IImplicitVertexSet<TVertex>
    {
        public FilteredImplicitVertexSet(
            TGraph baseGraph,
            VertexPredicate<TVertex> vertexPredicate,
            EdgePredicate<TVertex, TEdge> edgePredicate
            )
            :base(baseGraph,vertexPredicate,edgePredicate)
        { }

#if CTR        
        [Pure]
#endif
        public bool ContainsVertex(TVertex vertex)
        {
            return
                this.VertexPredicate(vertex) &&
                this.BaseGraph.ContainsVertex(vertex);
        }
    }
}
