﻿using System;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Predicates
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public sealed class SinkVertexPredicate<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        private readonly IIncidenceGraph<TVertex, TEdge> visitedGraph;

        public SinkVertexPredicate(IIncidenceGraph<TVertex, TEdge> visitedGraph)
        {
#if CTR
            Contract.Requires(visitedGraph != null);
#endif
            this.visitedGraph = visitedGraph;
        }

        public bool Test(TVertex v)
        {
            return this.visitedGraph.IsOutEdgesEmpty(v);
        }
    }
}
