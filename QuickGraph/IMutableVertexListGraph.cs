using System;
using System.Collections.Generic;
#if CTR        
using System.Diagnostics.Contracts;
#endif
using QuickGraph.Contracts;

namespace QuickGraph
{
    /// <summary>
    /// A mutable vertex list graph
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
#if CTR        
   [ContractClass(typeof(IMutableVertexListGraphContract<,>))]
#endif
   public interface IMutableVertexListGraph<TVertex, TEdge> : 
        IMutableIncidenceGraph<TVertex, TEdge>,
        IMutableVertexSet<TVertex>
        where TEdge : IEdge<TVertex>
    {
    }
}
