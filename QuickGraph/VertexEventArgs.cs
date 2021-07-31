using System;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public abstract class VertexEventArgs<TVertex> : EventArgs
    {
        private readonly TVertex vertex;
        protected VertexEventArgs(TVertex vertex)
        {
#if CTR
            Contract.Requires(vertex != null);
#endif
            this.vertex = vertex;
        }

        public TVertex Vertex
        {
            get { return this.vertex; }
        }
    }

    public delegate void VertexAction<TVertex>(TVertex vertex);
}
