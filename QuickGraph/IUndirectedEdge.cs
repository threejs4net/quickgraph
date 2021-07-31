using System;
#if CTR        
using System.Diagnostics.Contracts;
using QuickGraph.Contracts;
#endif

namespace QuickGraph
{
    /// <summary>
    /// An undirected edge. 
    /// </summary>
    /// <remarks>
    /// Invariant: source must be less or equal to target (using the default comparer)
    /// </remarks>
    /// <typeparam name="TVertex">type of the vertices</typeparam>
#if CTR        
    [ContractClass(typeof(IUndirectedEdgeContract<>))]
#endif
    public interface IUndirectedEdge<TVertex>
        : IEdge<TVertex>
    {
    }
}
