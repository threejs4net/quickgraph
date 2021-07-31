using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Contracts
{
#if CTR
    [ContractClassFor(typeof(ICloneableEdge<,>))]
#endif
    abstract class ICloneableEdgeContract<TVertex, TEdge>
        : ICloneableEdge<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
        TEdge ICloneableEdge<TVertex, TEdge>.Clone(TVertex source, TVertex target)
        {
#if CTR
            Contract.Requires(source != null);
            Contract.Requires(target != null);
            Contract.Ensures(Contract.Result<TEdge>() != null);
            Contract.Ensures(Contract.Result<TEdge>().Source.Equals(source));
            Contract.Ensures(Contract.Result<TEdge>().Target.Equals(target));
#endif
            return default(TEdge);
        }

        #region IEdge<TVertex> Members

        TVertex IEdge<TVertex>.Source
        {
            get { throw new NotImplementedException(); }
        }

        TVertex IEdge<TVertex>.Target
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
