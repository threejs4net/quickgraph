﻿using System;

#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Algorithms
{
#if CTR
    [ContractClass(typeof(Contracts.IComputationContract))]
#endif
    public interface IComputation
    {
        object SyncRoot { get; }
        ComputationState State { get; }

        void Compute();
        void Abort();

        event EventHandler StateChanged;
        event EventHandler Started;
        event EventHandler Finished;
        event EventHandler Aborted;
    }
}
