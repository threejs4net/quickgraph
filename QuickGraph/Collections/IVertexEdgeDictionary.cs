﻿using System;
using System.Collections.Generic;
#if !SILVERLIGHT
using System.Runtime.Serialization;
#endif
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Collections
{
    /// <summary>
    /// A dictionary of vertices to a list of edges
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
#if CTR
    [ContractClass(typeof(IVertexEdgeDictionaryContract<,>))]
#endif
    public interface IVertexEdgeDictionary<TVertex, TEdge>
        : IDictionary<TVertex, IEdgeList<TVertex, TEdge>>
#if !SILVERLIGHT
        , ICloneable
        , ISerializable
#endif
     where TEdge : IEdge<TVertex>
    {
        /// <summary>
        /// Gets a clone of the dictionary. The vertices and edges are not cloned.
        /// </summary>
        /// <returns></returns>
#if !SILVERLIGHT
        new 
#endif
        IVertexEdgeDictionary<TVertex, TEdge> Clone();
    }
}
