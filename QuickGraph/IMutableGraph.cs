using System;

#if CTR        
using System.Diagnostics.Contracts;
using QuickGraph.Contracts;
#endif

namespace QuickGraph
{
    /// <summary>
    /// A mutable graph instance
    /// </summary>
    /// <typeparam name="TVertex">type of the vertices</typeparam>
    /// <typeparam name="TEdge">type of the edges</typeparam>
#if CTR        
    [ContractClass(typeof(IMutableGraphContract<,>))]
#endif
    public interface IMutableGraph<TVertex,TEdge> 
        : IGraph<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
        /// <summary>
        /// Clears the vertex and edges
        /// </summary>
        void Clear();

        /// <summary>
        /// Called when the graph vertices and edges have been cleared.
        /// </summary>
        event EventHandler Cleared;
    }
}
