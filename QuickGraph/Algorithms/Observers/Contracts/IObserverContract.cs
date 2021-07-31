using System;

#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Algorithms.Observers.Contracts
{
#if CTR
    [ContractClassFor(typeof(IObserver<>))]
#endif
    abstract class IObserverContract<TAlgorithm>
        : IObserver<TAlgorithm>
    {
        IDisposable IObserver<TAlgorithm>.Attach(TAlgorithm algorithm)
        {
#if CTR
            Contract.Requires(algorithm != null);
            Contract.Ensures(Contract.Result<IDisposable>() != null);
#endif
            return default(IDisposable);
        }
    }
}
