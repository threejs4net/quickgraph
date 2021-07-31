using System;
using System.Collections.Generic;
#if !SILVERLIGHT
using System.Runtime.Serialization;
#endif
using System.Diagnostics;
#if CTR
using System.Diagnostics.Contracts;
using QuickGraph.Contracts;
#endif
using QuickGraph.Collections;
using System.Linq;

namespace QuickGraph
{
    /// <summary>
    /// A mutable directed graph data structure efficient for sparse
    /// graph representation where out-edge and in-edges need to be enumerated. Requires
    /// twice as much memory as the adjacency graph.
    /// </summary>
    /// <typeparam name="TVertex">type of the vertices</typeparam>
    /// <typeparam name="TEdge">type of the edges</typeparam>
#if !SILVERLIGHT
    [Serializable]
#endif
    [DebuggerDisplay("VertexCount = {VertexCount}, EdgeCount = {EdgeCount}")]
    public class BidirectionalGraph<TVertex, TEdge> 
        : IVertexAndEdgeListGraph<TVertex, TEdge>
        , IEdgeListAndIncidenceGraph<TVertex, TEdge>
        , IMutableEdgeListGraph<TVertex, TEdge>
        , IMutableIncidenceGraph<TVertex, TEdge>
        , IMutableVertexListGraph<TVertex, TEdge>
        , IBidirectionalGraph<TVertex,TEdge>
        , IMutableBidirectionalGraph<TVertex,TEdge>
        , IMutableVertexAndEdgeListGraph<TVertex, TEdge>
#if !SILVERLIGHT
        , ICloneable
#endif
        where TEdge : IEdge<TVertex>
    {
        private readonly bool isDirected = true;
        private readonly bool allowParallelEdges;
        private readonly IVertexEdgeDictionary<TVertex, TEdge> vertexOutEdges;
        private readonly IVertexEdgeDictionary<TVertex, TEdge> vertexInEdges;
        private int edgeCount = 0;
        private int edgeCapacity = -1;

        public BidirectionalGraph()
            :this(true)
        {}

        public BidirectionalGraph(bool allowParallelEdges)
            :this(allowParallelEdges,-1)
        {
        }

        public BidirectionalGraph(bool allowParallelEdges, int vertexCapacity)
            :this(allowParallelEdges, vertexCapacity, -1)
        {
        }

        public BidirectionalGraph(bool allowParallelEdges, int vertexCapacity, int edgeCapacity)
            :this(allowParallelEdges, vertexCapacity, edgeCapacity, EqualityComparer<TVertex>.Default)
        {
        }

        public BidirectionalGraph(bool allowParallelEdges, int vertexCapacity, int edgeCapacity, IEqualityComparer<TVertex> vertexComparer)
        {
#if CTR        
            Contract.Requires(vertexComparer != null);
#endif
            this.allowParallelEdges = allowParallelEdges;
            if (vertexCapacity > -1)
            {
                this.vertexInEdges = new VertexEdgeDictionary<TVertex, TEdge>(vertexCapacity, vertexComparer);
                this.vertexOutEdges = new VertexEdgeDictionary<TVertex, TEdge>(vertexCapacity, vertexComparer);
            }
            else
            {
                this.vertexInEdges = new VertexEdgeDictionary<TVertex, TEdge>(vertexComparer);
                this.vertexOutEdges = new VertexEdgeDictionary<TVertex, TEdge>(vertexComparer);
            }
            this.edgeCapacity = edgeCapacity;
        }

        public BidirectionalGraph(
            bool allowParallelEdges, 
            int capacity, 
            Func<int, IVertexEdgeDictionary<TVertex, TEdge>> vertexEdgesDictionaryFactory)
        {
#if CTR        
            Contract.Requires(vertexEdgesDictionaryFactory != null);
#endif
            this.allowParallelEdges = allowParallelEdges;
            this.vertexInEdges = vertexEdgesDictionaryFactory(capacity);
            this.vertexOutEdges = vertexEdgesDictionaryFactory(capacity);
        }
 
        public static Type EdgeType
        {
#if CTR        
        [Pure] 
#endif

            get { return typeof(TEdge); }
        }

        public int EdgeCapacity
        {
#if CTR        
        [Pure] 
#endif

            get { return this.edgeCapacity; }
            set { this.edgeCapacity = value; }
        }

        public bool IsDirected
        {
#if CTR        
        [Pure] 
#endif

            get { return this.isDirected; }
        }

        public bool AllowParallelEdges
        {
#if CTR        
        [Pure] 
#endif

            get { return this.allowParallelEdges; }
        }

        public bool IsVerticesEmpty
        {
#if CTR        
        [Pure] 
#endif

            get { return this.vertexOutEdges.Count == 0; }
        }

        public int VertexCount
        {
#if CTR        
        [Pure] 
#endif

            get { return this.vertexOutEdges.Count; }
        }

        public virtual IEnumerable<TVertex> Vertices
        {
#if CTR        
        [Pure] 
#endif

            get { return this.vertexOutEdges.Keys; }
        }

#if CTR        
        [Pure] 
#endif

        public bool ContainsVertex(TVertex v)
        {
            return this.vertexOutEdges.ContainsKey(v);
        }

#if CTR        
        [Pure] 
#endif

        public bool IsOutEdgesEmpty(TVertex v)
        {
            return this.vertexOutEdges[v].Count == 0;
        }

#if CTR        
        [Pure] 
#endif

        public int OutDegree(TVertex v)
        {
            return this.vertexOutEdges[v].Count;
        }

#if CTR        
        [Pure] 
#endif

        public IEnumerable<TEdge> OutEdges(TVertex v)
        {
            return this.vertexOutEdges[v];
        }

#if CTR        
        [Pure] 
#endif

        public bool TryGetInEdges(TVertex v, out IEnumerable<TEdge> edges)
        {
            IEdgeList<TVertex, TEdge> list;
            if (this.vertexInEdges.TryGetValue(v, out list))
            {
                edges = list;
                return true;
            }

            edges = null;
            return false;
        }

#if CTR        
        [Pure] 
#endif

        public bool TryGetOutEdges(TVertex v, out IEnumerable<TEdge> edges)
        {
            IEdgeList<TVertex, TEdge> list;
            if (this.vertexOutEdges.TryGetValue(v, out list))
            {
                edges = list;
                return true;
            }

            edges = null;
            return false;
        }

#if CTR        
        [Pure] 
#endif

        public TEdge OutEdge(TVertex v, int index)
        {
            return this.vertexOutEdges[v][index];
        }

#if CTR        
        [Pure] 
#endif

        public bool IsInEdgesEmpty(TVertex v)
        {
            return this.vertexInEdges[v].Count == 0;
        }

#if CTR        
        [Pure] 
#endif

        public int InDegree(TVertex v)
        {
            return this.vertexInEdges[v].Count;
        }

#if CTR        
        [Pure] 
#endif

        public IEnumerable<TEdge> InEdges(TVertex v)
        {
            return this.vertexInEdges[v];
        }

#if CTR        
        [Pure] 
#endif

        public TEdge InEdge(TVertex v, int index)
        {
            return this.vertexInEdges[v][index];
        }

#if CTR        
        [Pure] 
#endif

        public int Degree(TVertex v)
        {
            return this.OutDegree(v) + this.InDegree(v);
        }

        public bool IsEdgesEmpty
        {
            get { return this.edgeCount == 0; }
        }

        public int EdgeCount
        {
            get 
            {
                return this.edgeCount; 
            }
        }

        public virtual IEnumerable<TEdge> Edges
        {
            get
            {
                foreach (var edges in this.vertexOutEdges.Values)
                    foreach (var edge in edges)
                        yield return edge;
            }
        }

#if CTR        
        [Pure] 
#endif

        public bool ContainsEdge(TVertex source, TVertex target)
        {
            IEnumerable<TEdge> outEdges;
            if (!this.TryGetOutEdges(source, out outEdges))
                return false;
            foreach (var outEdge in outEdges)
                if (outEdge.Target.Equals(target))
                    return true;
            return false;
        }

#if CTR        
        [Pure] 
#endif

        public bool TryGetEdge(
            TVertex source,
            TVertex target,
            out TEdge edge)
        {
            IEdgeList<TVertex, TEdge> edgeList;
            if (this.vertexOutEdges.TryGetValue(source, out edgeList) &&
                edgeList.Count > 0)
            {
                foreach (var e in edgeList)
                {
                    if (e.Target.Equals(target))
                    {
                        edge = e;
                        return true;
                    }
                }
            }
            edge = default(TEdge);
            return false;
        }

#if CTR        
        [Pure] 
#endif

        public bool TryGetEdges(
            TVertex source,
            TVertex target,
            out IEnumerable<TEdge> edges)
        {
            IEdgeList<TVertex, TEdge> edgeList;
            if (this.vertexOutEdges.TryGetValue(source, out edgeList))
            {
                List<TEdge> list = new List<TEdge>(edgeList.Count);
                foreach (var edge in edgeList)
                    if (edge.Target.Equals(target))
                        list.Add(edge);
                edges = list;
                return true;
            }
            else
            {
                edges = null;
                return false;
            }
        }

#if CTR        
        [Pure] 
#endif

        public bool ContainsEdge(TEdge edge)
        {
            IEdgeList<TVertex, TEdge> outEdges;
            return this.vertexOutEdges.TryGetValue(edge.Source, out outEdges) &&
                outEdges.Contains(edge);
        }

        public virtual bool AddVertex(TVertex v)
        {
            if (this.ContainsVertex(v))
                return false;

            if (this.EdgeCapacity > 0)
            {
                this.vertexOutEdges.Add(v, new EdgeList<TVertex, TEdge>(this.EdgeCapacity));
                this.vertexInEdges.Add(v, new EdgeList<TVertex, TEdge>(this.EdgeCapacity));
            }
            else
            {
                this.vertexOutEdges.Add(v, new EdgeList<TVertex, TEdge>());
                this.vertexInEdges.Add(v, new EdgeList<TVertex, TEdge>());
            }
            this.OnVertexAdded(v);
            return true;
        }

        public virtual int AddVertexRange(IEnumerable<TVertex> vertices)
        {
            int count = 0;
            foreach (var v in vertices)
                if (this.AddVertex(v))
                    count++;
            return count;
        }

        public event VertexAction<TVertex> VertexAdded;
        protected virtual void OnVertexAdded(TVertex args)
        {
            var eh = this.VertexAdded;
            if (eh != null)
                eh(args);
        }

        public virtual bool RemoveVertex(TVertex v)
        {
            if (!this.ContainsVertex(v))
                return false;

            // collect edges to remove
            var edgesToRemove = new EdgeList<TVertex, TEdge>();
            foreach (var outEdge in this.OutEdges(v))
            {
                this.vertexInEdges[outEdge.Target].Remove(outEdge);
                edgesToRemove.Add(outEdge);
            }
            foreach (var inEdge in this.InEdges(v))
            {
                // might already have been removed
                if(this.vertexOutEdges[inEdge.Source].Remove(inEdge))
                    edgesToRemove.Add(inEdge);
            }

            // notify users
            if (this.EdgeRemoved != null)
            {
                foreach(TEdge edge in edgesToRemove)
                    this.OnEdgeRemoved(edge);
            }

            this.vertexOutEdges.Remove(v);
            this.vertexInEdges.Remove(v);
            this.edgeCount -= edgesToRemove.Count;
            this.OnVertexRemoved(v);

            return true;
        }

        public event VertexAction<TVertex> VertexRemoved;
        protected virtual void OnVertexRemoved(TVertex args)
        {
            var eh = this.VertexRemoved;
            if (eh != null)
                eh(args);
        }

        public int RemoveVertexIf(VertexPredicate<TVertex> predicate)
        {
            var vertices = new VertexList<TVertex>();
            foreach (var v in this.Vertices)
                if (predicate(v))
                    vertices.Add(v);

            foreach (var v in vertices)
                this.RemoveVertex(v);
            return vertices.Count;
        }

        public virtual bool AddEdge(TEdge e)
        {
            if (!this.AllowParallelEdges)
            {
                if (this.ContainsEdge(e.Source, e.Target))
                    return false;
            }
            this.vertexOutEdges[e.Source].Add(e);
            this.vertexInEdges[e.Target].Add(e);
            this.edgeCount++;

            this.OnEdgeAdded(e);

            return true;
        }

        public int AddEdgeRange(IEnumerable<TEdge> edges)
        {
            int count = 0;
            foreach (var edge in edges)
                if (this.AddEdge(edge))
                    count++;
            return count;
        }

        public virtual bool AddVerticesAndEdge(TEdge e)
        {
            this.AddVertex(e.Source);
            this.AddVertex(e.Target);
            return this.AddEdge(e);
        }

        public int AddVerticesAndEdgeRange(IEnumerable<TEdge> edges)
        {
            int count = 0;
            foreach (var edge in edges)
                if (this.AddVerticesAndEdge(edge))
                    count++;
            return count;
        }

        public event EdgeAction<TVertex, TEdge> EdgeAdded;
        protected virtual void OnEdgeAdded(TEdge args)
        {
            var eh = this.EdgeAdded;
            if (eh != null)
                eh(args);
        }

        public virtual bool RemoveEdge(TEdge e)
        {
            if (this.vertexOutEdges[e.Source].Remove(e))
            {
                this.vertexInEdges[e.Target].Remove(e);
                this.edgeCount--;
#if CTR        
                Contract.Assert(this.edgeCount >= 0);
#endif

                this.OnEdgeRemoved(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public event EdgeAction<TVertex, TEdge> EdgeRemoved;
        protected virtual void OnEdgeRemoved(TEdge args)
        {
            var eh = this.EdgeRemoved;
            if (eh != null)
                eh(args);
        }

        public int RemoveEdgeIf(EdgePredicate<TVertex, TEdge> predicate)
        {
            var edges = new EdgeList<TVertex, TEdge>();
            foreach (var edge in this.Edges)
                if (predicate(edge))
                    edges.Add(edge);

            foreach (var edge in edges)
                this.RemoveEdge(edge);
            return edges.Count;
        }

        public int RemoveOutEdgeIf(TVertex v, EdgePredicate<TVertex, TEdge> predicate)
        {
            var edges = new EdgeList<TVertex, TEdge>();
            foreach (var edge in this.OutEdges(v))
                if (predicate(edge))
                    edges.Add(edge);
            foreach (var edge in edges)
                this.RemoveEdge(edge);
            return edges.Count;
        }

        public int RemoveInEdgeIf(TVertex v, EdgePredicate<TVertex, TEdge> predicate)
        {
            var edges = new EdgeList<TVertex, TEdge>();
            foreach (var edge in this.InEdges(v))
                if (predicate(edge))
                    edges.Add(edge);
            foreach (var edge in edges)
                this.RemoveEdge(edge);
            return edges.Count;
        }

        public void ClearOutEdges(TVertex v)
        {
            var outEdges = this.vertexOutEdges[v];
            foreach (var edge in outEdges)
            {
                this.vertexInEdges[edge.Target].Remove(edge);
                this.OnEdgeRemoved(edge);
            }

            this.edgeCount -= outEdges.Count;
            outEdges.Clear();
        }

#if DEEP_INVARIANT
        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(this.edgeCount >= 0);
            Contract.Invariant(Enumerable.Sum(this.vertexInEdges.Values, ie => ie.Count) == this.edgeCount);
            Contract.Invariant(this.vertexInEdges.Count == this.vertexOutEdges.Count);
            Contract.Invariant(Enumerable.All(this.vertexInEdges, kv => this.vertexOutEdges.ContainsKey(kv.Key)));
            Contract.Invariant(Enumerable.All(this.vertexOutEdges, kv => this.vertexInEdges.ContainsKey(kv.Key)));
        }
#endif

        public void ClearInEdges(TVertex v)
        {
            var inEdges = this.vertexInEdges[v];
            foreach (var edge in inEdges)
            {
                this.vertexOutEdges[edge.Source].Remove(edge);
                this.OnEdgeRemoved(edge);
            }

            this.edgeCount -= inEdges.Count;
            inEdges.Clear();
        }

        public void ClearEdges(TVertex v)
        {
            ClearOutEdges(v);
            ClearInEdges(v);
        }

        public void TrimEdgeExcess()
        {
            foreach (var edges in this.vertexInEdges.Values)
                edges.TrimExcess();
            foreach (var edges in this.vertexOutEdges.Values)
                edges.TrimExcess();
        }

        public void Clear()
        {
            this.vertexOutEdges.Clear();
            this.vertexInEdges.Clear();
            this.edgeCount = 0;
            this.OnCleared(EventArgs.Empty);
        }

        public event EventHandler Cleared;
        private void OnCleared(EventArgs e)
        {
            var eh = this.Cleared;
            if (eh != null)
                eh(this, e);
        }

        public void MergeVertex(TVertex v, EdgeFactory<TVertex, TEdge> edgeFactory)
        {
#if CTR        
            Contract.Requires(GraphContract.InVertexSet(this, v));
            Contract.Requires(edgeFactory != null);
#endif
            // storing edges in local array
            var inedges = this.vertexInEdges[v];
            var outedges = this.vertexOutEdges[v];

            // remove vertex
            this.RemoveVertex(v);

            // add edges from each source to each target
            foreach (var source in inedges)
            {
                //is it a self edge
                if (source.Source.Equals(v))
                    continue;
                foreach (var target in outedges)
                {
                    if (v.Equals(target.Target))
                        continue;
                    // we add an new edge
                    this.AddEdge(edgeFactory(source.Source, target.Target));
                }
            }
        }

        public void MergeVertexIf(VertexPredicate<TVertex> vertexPredicate, EdgeFactory<TVertex, TEdge> edgeFactory)
        {
#if CTR        

            Contract.Requires(vertexPredicate != null);
            Contract.Requires(edgeFactory != null);
#endif

            // storing vertices to merge
            var mergeVertices = new VertexList<TVertex>(this.VertexCount / 4);
            foreach (var v in this.Vertices)
                if (vertexPredicate(v))
                    mergeVertices.Add(v);

            // applying merge recursively
            foreach (var v in mergeVertices)
                MergeVertex(v, edgeFactory);
        }

        #region ICloneable Members
        private BidirectionalGraph(
            IVertexEdgeDictionary<TVertex, TEdge> vertexInEdges,
            IVertexEdgeDictionary<TVertex, TEdge> vertexOutEdges,
            int edgeCount,
            int edgeCapacity,
            bool allowParallelEdges
            )
        {
#if CTR        

            Contract.Requires(vertexInEdges != null);
            Contract.Requires(vertexOutEdges != null);
            Contract.Requires(edgeCount >= 0);
#endif
            this.vertexInEdges = vertexInEdges;
            this.vertexOutEdges = vertexOutEdges;
            this.edgeCount = edgeCount;
            this.edgeCapacity = edgeCapacity;
            this.allowParallelEdges = allowParallelEdges;
        }

        public BidirectionalGraph<TVertex, TEdge> Clone()
        {
            return new BidirectionalGraph<TVertex, TEdge>(
                this.vertexInEdges.Clone(),
                this.vertexOutEdges.Clone(),
                this.edgeCount,
                this.edgeCapacity,
                this.allowParallelEdges
                );
        }
        
#if !SILVERLIGHT
        object ICloneable.Clone()
        {
            return this.Clone();
        }
#endif
        #endregion
    }
}
