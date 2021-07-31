using System;
#if CTR        
using System.Diagnostics.Contracts;
#endif
namespace QuickGraph
{
#if CTR        
    [Pure]
#endif
    public delegate bool EdgePredicate<TVertex, TEdge>(TEdge e)
        where TEdge : IEdge<TVertex>;
}
