using System;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Algorithms.Contracts
{
#if CTR
    [ContractClassFor(typeof(IComputation))]
#endif
    abstract class IComputationContract
        : IComputation
    {
        #region IComputation Members
        object IComputation.SyncRoot
        {
            get
            {
#if CTR
                Contract.Ensures(Contract.Result<object>() != null);
#endif
                return null;
            }
        }

        ComputationState IComputation.State
        {
            get 
            {
#if CTR
                Contract.Ensures(Enum.IsDefined(typeof(ComputationState), Contract.Result<ComputationState>()));
#endif
                return default(ComputationState);
            }
        }

        void IComputation.Compute()
        {
            // todo contracts on events
        }

        void IComputation.Abort()
        {
        }

        event EventHandler IComputation.StateChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler IComputation.Started
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler IComputation.Finished
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler IComputation.Aborted
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        #endregion
    }
}
