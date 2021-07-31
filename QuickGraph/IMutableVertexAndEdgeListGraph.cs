using System;
using System.Collections.Generic;
#if CTR        
using QuickGraph.Contracts;
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
    /// <summary>
    /// A mutable vertex and edge list graph
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public interface IMutableVertexAndEdgeListGraph<TVertex,TEdge>
        : IMutableVertexListGraph<TVertex,TEdge>
        , IMutableEdgeListGraph<TVertex,TEdge>
        , IMutableVertexAndEdgeSet<TVertex,TEdge>
        , IVertexAndEdgeListGraph<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
    }
}
