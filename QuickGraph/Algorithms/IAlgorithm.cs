using System;
using QuickGraph.Algorithms.Services;
#if CTR
using System.Diagnostics.Contracts;
#endif
namespace QuickGraph.Algorithms
{
#if CTR
   [ContractClass(typeof(Contracts.IAlgorithmContract<>))]
#endif
    public interface IAlgorithm<TGraph> :
        IComputation
    {
        TGraph VisitedGraph { get;}
    }
}
