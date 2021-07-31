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
    [ContractClassFor(typeof(IEdgeSet<,>))]
#endif
    abstract class IEdgeSetContract<TVertex, TEdge> 
        : IEdgeSet<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        bool IEdgeSet<TVertex, TEdge>.IsEdgesEmpty
        {
            get 
            {
                IEdgeSet<TVertex, TEdge> ithis = this;
#if CTR
                Contract.Ensures(Contract.Result<bool>() == (ithis.EdgeCount == 0));
#endif

                return default(bool);
            }
        }

        int IEdgeSet<TVertex, TEdge>.EdgeCount
        {
            get
            {
                IEdgeSet<TVertex, TEdge> ithis = this;
#if CTR
                Contract.Ensures(Contract.Result<int>() == Enumerable.Count(ithis.Edges));
#endif

                return default(int);
            }
        }

        IEnumerable<TEdge> IEdgeSet<TVertex, TEdge>.Edges
        {
            get 
            {
#if CTR
                Contract.Ensures(Contract.Result<IEnumerable<TEdge>>() != null);
                Contract.Ensures(Enumerable.All<TEdge>(Contract.Result<IEnumerable<TEdge>>(), e => e != null));
#endif

                return default(IEnumerable<TEdge>);            
            }
        }

        [Pure]
        bool IEdgeSet<TVertex, TEdge>.ContainsEdge(TEdge edge)
        {
            IEdgeSet<TVertex, TEdge> ithis = this;
#if CTR
            Contract.Requires(edge != null);
            Contract.Ensures(Contract.Result<bool>() == Contract.Exists(ithis.Edges, e => e.Equals(edge)));
#endif

            return default(bool);
        }
    }
}
