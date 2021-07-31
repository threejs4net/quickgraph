using System.Collections.Generic;
using QuickGraph.Algorithms.Services;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Algorithms.RankedShortestPath
{
    public abstract class RankedShortestPathAlgorithmBase<TVertex, TEdge, TGraph>
        : RootedAlgorithmBase<TVertex, TGraph>
        where TEdge : IEdge<TVertex>
        where TGraph : IGraph<TVertex, TEdge>
    {
        private readonly IDistanceRelaxer distanceRelaxer;
        private int shortestPathCount = 3;
        private List<IEnumerable<TEdge>> computedShortestPaths;

        public int ShortestPathCount
        {
            get { return this.shortestPathCount; }
            set
            {
#if CTR
                Contract.Requires(value > 1);
                Contract.Ensures(this.ShortestPathCount == value);
#endif

                this.shortestPathCount = value;
            }
        }

        public int ComputedShortestPathCount
        {
            get
            {
#if CTR
                Contract.Ensures(Contract.Result<int>() == Enumerable.Count(this.ComputedShortestPaths));
#endif
                return this.computedShortestPaths == null ? 0 : this.computedShortestPaths.Count;
            }
        }

        public IEnumerable<IEnumerable<TEdge>> ComputedShortestPaths
        {
            get
            {
                if (this.computedShortestPaths == null)
                    yield break;
                else
                    foreach (var path in this.computedShortestPaths)
                        yield return path;
            }
        }

        protected void AddComputedShortestPath(List<TEdge> path)
        {
#if CTR
            Contract.Requires(path != null);
            Contract.Requires(Enumerable.All(path, e => e != null));
#endif
            var pathArray = path.ToArray();
            this.computedShortestPaths.Add(pathArray);
        }

        public IDistanceRelaxer DistanceRelaxer
        {
            get { return this.distanceRelaxer; }
        }

        protected RankedShortestPathAlgorithmBase(
            IAlgorithmComponent host, 
            TGraph visitedGraph,
            IDistanceRelaxer distanceRelaxer)
            : base(host, visitedGraph)
        {
#if CTR
            Contract.Requires(distanceRelaxer != null);
#endif
            this.distanceRelaxer = distanceRelaxer;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.computedShortestPaths = new List<IEnumerable<TEdge>>(this.ShortestPathCount);
        }
    }
}
