using System;
using System.Collections.Generic;
#if CTR        
using System.Diagnostics.Contracts;
#endif
using QuickGraph.Contracts;

namespace QuickGraph
{
    /// <summary>
    /// A mutable vertex set
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
#if CTR        
    [ContractClass(typeof(IMutableVertexSetContract<>))]
#endif
    public interface IMutableVertexSet<TVertex>
        : IVertexSet<TVertex>
    {
        event VertexAction<TVertex> VertexAdded;
        bool AddVertex(TVertex v);
        int AddVertexRange(IEnumerable<TVertex> vertices);

        event VertexAction<TVertex> VertexRemoved;
        bool RemoveVertex(TVertex v);
        int RemoveVertexIf(VertexPredicate<TVertex> pred);
    }
}
