#if !SILVERLIGHT
using System;
using System.Collections.Generic;
using QuickGraph.Collections;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Algorithms.Exploration
{
    public sealed class TransitionFactoryImplicitGraph<TVertex,TEdge> 
        : IImplicitGraph<TVertex,TEdge>
        where TVertex : ICloneable
        where TEdge : IEdge<TVertex>
    {
        private readonly VertexEdgeDictionary<TVertex, TEdge> vertedEdges =
            new VertexEdgeDictionary<TVertex, TEdge>();
        private readonly List<ITransitionFactory<TVertex, TEdge>> transitionFactories
            = new List<ITransitionFactory<TVertex, TEdge>>();
        private VertexPredicate<TVertex> successorVertexPredicate
            = v => true;
        private EdgePredicate<TVertex, TEdge> successorEdgePredicate
            = e => true;

        public TransitionFactoryImplicitGraph()
        {}

        public IList<ITransitionFactory<TVertex, TEdge>> TransitionFactories
        {
            get { return this.transitionFactories; }
        }

        public VertexPredicate<TVertex> SuccessorVertexPredicate
        {
            get { return this.successorVertexPredicate; }
            set { this.successorVertexPredicate = value; }
        }

        public EdgePredicate<TVertex, TEdge> SuccessorEdgePredicate
        {
            get { return this.successorEdgePredicate; }
            set { this.successorEdgePredicate = value; }
        }

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
            int i = 0;
            foreach(TEdge edge in this.OutEdges(v))
                i++;
            return i;
        }

#if CTR        
        [Pure]
#endif

        public bool ContainsVertex(TVertex vertex)
        {
            return this.vertedEdges.ContainsKey(vertex);
        }

#if CTR        
        [Pure]
#endif

        public IEnumerable<TEdge> OutEdges(TVertex v)
        {
            IEdgeList<TVertex, TEdge> edges;
            if (!this.vertedEdges.TryGetValue(v, out edges))
            {
                edges = new EdgeList<TVertex, TEdge>();
                foreach (ITransitionFactory<TVertex, TEdge> transitionFactory
                    in this.TransitionFactories)
                {
                    if (!transitionFactory.IsValid(v))
                        continue;

                    foreach (var edge in transitionFactory.Apply(v))
                    {
                        if (this.SuccessorVertexPredicate(edge.Target) &&
                            this.SuccessorEdgePredicate(edge))
                            edges.Add(edge);
                    }
                }
                this.vertedEdges[v] = edges;
            }
            return edges;
        }

#if CTR        
        [Pure]
#endif

        public bool TryGetOutEdges(TVertex v, out IEnumerable<TEdge> edges)
        {
            edges = this.OutEdges(v);
            return true;
        }

#if CTR        
        [Pure]
#endif

        public TEdge OutEdge(TVertex v, int index)
        {
            int i = 0;
            foreach (var e in this.OutEdges(v))
                if (i++ == index)
                    return e;
            throw new ArgumentOutOfRangeException("index");
        }

        public bool IsDirected
        {
            get { return true; }
        }

        public bool AllowParallelEdges
        {
            get { return true; }
        }

    }
}
#endif