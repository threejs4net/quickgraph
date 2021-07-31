using System;
using System.Collections.Generic;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif
using System.Linq;

namespace QuickGraph.Contracts
{
#if CTR
    [ContractClassFor(typeof(IImplicitUndirectedGraph<,>))]
#endif
    abstract class IImplicitUndirectedGraphContract<TVertex, TEdge> 
        : IImplicitUndirectedGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        #region IImplicitUndirectedGraph<TVertex,TEdge> Members
#if CTR
        [Pure]
#endif

        EdgeEqualityComparer<TVertex, TEdge> IImplicitUndirectedGraph<TVertex, TEdge>.EdgeEqualityComparer
        {
            get
            {
#if CTR
                Contract.Ensures(Contract.Result<EdgeEqualityComparer<TVertex, TEdge>>() != null);
#endif
                return null;
            }
        }

#if CTR
        [Pure]
#endif

        IEnumerable<TEdge> IImplicitUndirectedGraph<TVertex, TEdge>.AdjacentEdges(TVertex v)
        {
            IImplicitUndirectedGraph<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(v != null);
            Contract.Requires(ithis.ContainsVertex(v));
            Contract.Ensures(Contract.Result<IEnumerable<TEdge>>() != null);
            Contract.Ensures(
                Enumerable.All(
                    Contract.Result<IEnumerable<TEdge>>(),
                    edge => 
                        edge != null && 
                        ithis.ContainsEdge(edge.Source, edge.Target) && 
                        (edge.Source.Equals(v) || edge.Target.Equals(v))
                    )
                );
#endif
            return default(IEnumerable<TEdge>);
        }

#if CTR
        [Pure]
#endif

        int IImplicitUndirectedGraph<TVertex, TEdge>.AdjacentDegree(TVertex v)
        {
            IImplicitUndirectedGraph<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(v != null);
            Contract.Requires(ithis.ContainsVertex(v));
            Contract.Ensures(Contract.Result<int>() == Enumerable.Count(ithis.AdjacentEdges(v)));
#endif
            return default(int);
        }

#if CTR
        [Pure]
#endif

        bool IImplicitUndirectedGraph<TVertex, TEdge>.IsAdjacentEdgesEmpty(TVertex v)
        {
            IImplicitUndirectedGraph<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(v != null);
            Contract.Requires(ithis.ContainsVertex(v));
            Contract.Ensures(Contract.Result<bool>() == (ithis.AdjacentDegree(v) == 0));
#endif
            return default(bool);
        }

#if CTR
        [Pure]
#endif

        TEdge IImplicitUndirectedGraph<TVertex, TEdge>.AdjacentEdge(TVertex v, int index)
        {
            IImplicitUndirectedGraph<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(v != null);
            Contract.Requires(ithis.ContainsVertex(v));
            Contract.Ensures(Contract.Result<TEdge>() != null);
            Contract.Ensures(
                Contract.Result<TEdge>().Source.Equals(v)
                || Contract.Result<TEdge>().Target.Equals(v));
#endif

            return default(TEdge);
        }

#if CTR
        [Pure]
#endif

        bool IImplicitUndirectedGraph<TVertex, TEdge>.TryGetEdge(TVertex source, TVertex target, out TEdge edge)
        {
            IImplicitUndirectedGraph<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(source != null);
            Contract.Requires(target != null);
#endif
            edge = default(TEdge);
            return default(bool);
        }

#if CTR
        [Pure]
#endif

        bool IImplicitUndirectedGraph<TVertex, TEdge>.ContainsEdge(TVertex source, TVertex target)
        {
            IImplicitUndirectedGraph<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(source != null);
            Contract.Requires(target != null);
            Contract.Ensures(Contract.Result<bool>() == Enumerable.Any(ithis.AdjacentEdges(source), e => e.Target.Equals(target) || e.Source.Equals(target)));
#endif
            return default(bool);
        }
        #endregion

        #region IImplicitVertexSet<TVertex> Members
        bool IImplicitVertexSet<TVertex>.ContainsVertex(TVertex vertex)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IGraph<TVertex,TEdge> Members

        public bool IsDirected {
          get { throw new NotImplementedException(); }
        }

        public bool AllowParallelEdges {
          get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
