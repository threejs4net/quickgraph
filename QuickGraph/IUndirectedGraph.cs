﻿using System;
using System.Collections.Generic;
#if CTR        
using System.Diagnostics.Contracts;
using QuickGraph.Contracts;
#endif

namespace QuickGraph
{
    /// <summary>
    /// An undirected graph
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
#if CTR        
    [ContractClass(typeof(IUndirectedGraphContract<,>))]
#endif
    public interface IUndirectedGraph<TVertex,TEdge> 
        : IImplicitUndirectedGraph<TVertex, TEdge>
        , IEdgeListGraph<TVertex,TEdge>
        , IGraph<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
    }
}
