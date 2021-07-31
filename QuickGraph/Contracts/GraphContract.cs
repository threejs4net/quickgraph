using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Contracts
{
    /// <summary>
    /// Debug only assertions and assumptions
    /// </summary>
    public static class GraphContract
    {
        [Pure]
        public static bool VertexCountEqual<TVertex>(
#if !NET20
            this 
#endif
            IVertexSet<TVertex> left,
            IVertexSet<TVertex> right)
        {
#if CTR
            Contract.Requires(left != null);
            Contract.Requires(right != null);
#endif
            return left.VertexCount == right.VertexCount;
        }

        [Pure]
        public static bool EdgeCountEqual<TVertex, TEdge>(
#if !NET20
            this 
#endif
            IEdgeListGraph<TVertex, TEdge> left,
            IEdgeListGraph<TVertex, TEdge> right)
            where TEdge : IEdge<TVertex>
        {
#if CTR
            Contract.Requires(left != null);
            Contract.Requires(right != null);
#endif
            return left.EdgeCount == right.EdgeCount;
        }

        [Pure]
        public static bool InVertexSet<TVertex>(
            IVertexSet<TVertex> g, 
            TVertex v)
        {
#if CTR
            Contract.Requires(g != null);
            Contract.Requires(v != null);
#endif
            // todo make requires
            return g.ContainsVertex(v);
        }

        [Pure]
        public static bool InVertexSet<TVertex, TEdge>(
            IEdgeListGraph<TVertex, TEdge> g,
            TEdge e)
            where TEdge : IEdge<TVertex>
        {
#if CTR
            Contract.Requires(g != null);
            Contract.Requires(e != null);
#endif

            return InVertexSet<TVertex>(g, e.Source)
                && InVertexSet<TVertex>(g, e.Target);
        }

        [Pure]
        public static bool InEdgeSet<TVertex, TEdge>(
            IEdgeListGraph<TVertex, TEdge> g,
            TEdge e)
            where TEdge : IEdge<TVertex>
        {
#if CTR
            Contract.Requires(g != null);
            Contract.Requires(e != null);
#endif
            
            return InVertexSet(g, e)
                && g.ContainsEdge(e);
        }
    }
}
