using QuickGraph.Contracts;
#if CTR        
using System.Diagnostics.Contracts;
#endif
namespace QuickGraph
{
    /// <summary>
    /// A directed edge
    /// </summary>
    /// <typeparam name="TVertex">type of the vertices</typeparam>
#if CTR        
    [ContractClass(typeof(IEdgeContract<>))]
#endif
    public interface IEdge<TVertex>
    {
        /// <summary>
        /// Gets the source vertex
        /// </summary>
        TVertex Source { get;}
        /// <summary>
        /// Gets the target vertex
        /// </summary>
        TVertex Target { get;}
    }
}
