using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Data
{
    public class DataSetGraph :
        BidirectionalGraph<DataTable, DataRelationEdge>
    {
        readonly DataSet dataSet;
        public DataSet DataSet
        {
            get { return this.dataSet; }
        }

        internal DataSetGraph(DataSet dataSet)
        {
#if CTR
            Contract.Requires(dataSet != null);
#endif
            this.dataSet = dataSet;
        }
    }
}
