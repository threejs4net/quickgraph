using System;
using System.Collections.Generic;

#if CTR
using System.Diagnostics.Contracts;
#endif
namespace QuickGraph.Algorithms.Observers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TVertex">type of a vertex</typeparam>
    /// <typeparam name="TEdge">type of an edge</typeparam>
    /// <reference-ref
    ///     idref="boost"
    ///     />
#if !SILVERLIGHT
    [Serializable]
#endif
    public sealed class EdgeRecorderObserver<TVertex, TEdge> :
        IObserver<ITreeBuilderAlgorithm<TVertex, TEdge>>
        where TEdge : IEdge<TVertex>
    {
        private readonly IList<TEdge> edges;

        public EdgeRecorderObserver()
            :this(new List<TEdge>())
        {}

        public EdgeRecorderObserver(IList<TEdge> edges)
        {
#if CTR
            Contract.Requires(edges != null);
#endif

            this.edges = edges;
        }

        public IList<TEdge> Edges
        {
            get
            {
                return this.edges;
            }
        }

        public IDisposable Attach(ITreeBuilderAlgorithm<TVertex, TEdge> algorithm)
        {
            algorithm.TreeEdge +=new EdgeAction<TVertex,TEdge>(RecordEdge);
            return new DisposableAction(
                () => algorithm.TreeEdge -= new EdgeAction<TVertex, TEdge>(RecordEdge)
                );
        }

        private void RecordEdge(TEdge args)
        {
#if CTR
            Contract.Requires(args != null);
#endif
            this.Edges.Add(args);
        }
    }
}
