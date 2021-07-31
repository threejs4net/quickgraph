using System;
using System.Collections.Generic;
using System.Text;
using QuickGraph.Graphviz.Dot;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Graphviz
{
#if CTR
    [ContractClass(typeof(IDotEngineContract))]
#endif
    public interface IDotEngine
    {
        string Run(
            GraphvizImageType imageType,
            string dot,
            string outputFileName);
    }

#if CTR
    [ContractClassFor(typeof(IDotEngine))]
#endif
    abstract class IDotEngineContract
        : IDotEngine
    {
        #region IDotEngine Members
        string IDotEngine.Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
#if CTR
            Contract.Requires(!String.IsNullOrEmpty(dot));
            Contract.Requires(!String.IsNullOrEmpty(outputFileName));
            Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));
#endif
            return null;
        }
        #endregion
    }
}
