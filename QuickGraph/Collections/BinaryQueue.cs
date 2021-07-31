using System;
using System.Collections.Generic;

#if CTR
using System.Diagnostics.Contracts;
#endif
namespace QuickGraph.Collections
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public sealed class BinaryQueue<TVertex, TDistance> : 
        IPriorityQueue<TVertex>
    {
        private readonly Func<TVertex, TDistance> distances;
        private readonly BinaryHeap<TDistance, TVertex> heap;

        public BinaryQueue(
            Func<TVertex, TDistance> distances
            )
            : this(distances, Comparer<TDistance>.Default.Compare)
        { }

		public BinaryQueue(
            Func<TVertex, TDistance> distances,
            Func<TDistance, TDistance, int> distanceComparison
            )
		{
#if CTR
            Contract.Requires(distances != null);
            Contract.Requires(distanceComparison != null);
#endif

			this.distances = distances;
            this.heap = new BinaryHeap<TDistance, TVertex>(distanceComparison);
		}

		public void Update(TVertex v)
		{
            this.heap.Update(this.distances(v), v);
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        public bool Contains(TVertex value)
        {
            return this.heap.IndexOf(value) > -1;
        }

        public void Enqueue(TVertex value)
        {
            this.heap.Add(this.distances(value), value);
        }

        public TVertex Dequeue()
        {
            return this.heap.RemoveMinimum().Value;
        }

        public TVertex Peek()
        {
            return this.heap.Minimum().Value;
        }

        public TVertex[] ToArray()
        {
            return this.heap.ToValueArray();
        }
    }
}
