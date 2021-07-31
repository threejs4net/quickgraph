using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#if CTR
using System.Diagnostics.Contracts;
#endif
using QuickGraph.Graphviz;

namespace QuickGraph.Data
{
    public static class DataSetGraphExtensions
    {
        public static DataSetGraph ToGraph(
#if !NET20
            this
#endif
            DataSet ds)
        {
#if CTR
            Contract.Requires(ds != null);
#endif
            var g = new DataSetGraph(ds);
            var populator = new DataSetGraphPopulatorAlgorithm(g, ds);
            populator.Compute();

            return g;
        }

        public static string ToGraphviz(
#if !NET20
this
#endif
            DataSetGraph visitedGraph)
        {
#if CTR
            Contract.Requires(visitedGraph != null);
#endif
            var algorithm = new DataSetGraphvizAlgorithm(visitedGraph);
            return algorithm.Generate();
        }
    }
}
