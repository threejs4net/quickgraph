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
    public class FilteredImplicitGraph<TVertex, TEdge, TGraph> 
        : FilteredImplicitVertexSet<TVertex, TEdge, TGraph>
        , IImplicitGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
        where TGraph : IImplicitGraph<TVertex, TEdge>
    {
        public FilteredImplicitGraph(
            TGraph baseGraph,
            VertexPredicate<TVertex> vertexPredicate,
            EdgePredicate<TVertex, TEdge> edgePredicate
            )
            :base(baseGraph,vertexPredicate,edgePredicate)
        { }

#if CTR        
        [Pure]
#endif
        public bool IsOutEdgesEmpty(TVertex v)
        {
            return this.OutDegree(v) == 0;
        }

#if CTR        
        [Pure]
#endif
        public int OutDegree(TVertex v)
        {
            int count =0;
            foreach (var edge in this.BaseGraph.OutEdges(v))
                if (this.TestEdge(edge))
                    count++;
            return count;
        }

#if CTR        
        [Pure]
#endif
        public IEnumerable<TEdge> OutEdges(TVertex v)
        {
            foreach (var edge in this.BaseGraph.OutEdges(v))
                if (this.TestEdge(edge))
                    yield return edge;
        }

#if CTR        
        [Pure]
#endif
        public bool TryGetOutEdges(TVertex v, out IEnumerable<TEdge> edges)
        {
            IEnumerable<TEdge> baseEdges;
            if (!this.BaseGraph.TryGetOutEdges(v, out baseEdges))
            {
                edges = null;
                return false;
            }

            edges = this.OutEdges(v);
            return true;
        }

#if CTR        
        [Pure]
#endif
        public TEdge OutEdge(TVertex v, int index)
        {
            throw new NotSupportedException();
        }
    }
}
