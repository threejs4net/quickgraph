using System;
using System.Collections.Generic;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif
using System.Linq;

namespace QuickGraph.Contracts
{
#if CTR
    [ContractClassFor(typeof(IVertexSet<>))]
#endif
    abstract class IVertexSetContract<TVertex>
        : IVertexSet<TVertex>
    {
        bool IVertexSet<TVertex>.IsVerticesEmpty
        {
            get 
            {
                IVertexSet<TVertex> ithis = this;
#if CTR
                Contract.Ensures(Contract.Result<bool>() == (ithis.VertexCount == 0));
#endif

                return default(bool);
            }
        }

        int IVertexSet<TVertex>.VertexCount
        {
            get
            {
                IVertexSet<TVertex> ithis = this;
#if CTR
                Contract.Ensures(Contract.Result<int>() == Enumerable.Count(ithis.Vertices));
#endif

                return default(int);
            }
        }

        IEnumerable<TVertex> IVertexSet<TVertex>.Vertices
        {
            get 
            {
#if CTR
                Contract.Ensures(Contract.Result<IEnumerable<TVertex>>() != null);
#endif

                return default(IEnumerable<TVertex>);
            }
        }

        #region IImplicitVertexSet<TVertex> Members

        public bool ContainsVertex(TVertex vertex) {
          throw new NotImplementedException();
        }

        #endregion
    }
}
