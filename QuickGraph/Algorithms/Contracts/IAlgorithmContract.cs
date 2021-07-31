﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Algorithms.Contracts
{
#if CTR
    [ContractClassFor(typeof(IAlgorithm<>))]
#endif
    abstract class IAlgorithmContract<TGraph>
        : IAlgorithm<TGraph>
    {
        #region IAlgorithm<TGraph> Members

        TGraph IAlgorithm<TGraph>.VisitedGraph
        {
            get 
            {
#if CTR
                Contract.Ensures(Contract.Result<TGraph>() != null);
#endif
                return default(TGraph);
            }
        }

        #endregion

        #region IComputation Members

        object IComputation.SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        ComputationState IComputation.State
        {
            get { throw new NotImplementedException(); }
        }

        void IComputation.Compute()
        {
            throw new NotImplementedException();
        }

        void IComputation.Abort()
        {
            throw new NotImplementedException();
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