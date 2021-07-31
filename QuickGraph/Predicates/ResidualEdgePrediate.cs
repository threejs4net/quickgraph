using System.Collections.Generic;

#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Predicates
{
    public sealed class ResidualEdgePredicate<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
		private readonly IDictionary<TEdge,double> residualCapacities;

        public ResidualEdgePredicate(
            IDictionary<TEdge,double> residualCapacities)
		{
#if CTR
            Contract.Requires(residualCapacities != null);
#endif
            this.residualCapacities = residualCapacities;
		}

		public IDictionary<TEdge,double> ResidualCapacities
		{
			get
			{
				return this.residualCapacities;
			}
		}

		public bool Test(TEdge e)
		{
#if CTR
            Contract.Requires(e != null);
#endif
			return 0 < this.residualCapacities[e];
		}
    }
}
