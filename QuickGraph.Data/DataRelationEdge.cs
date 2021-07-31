using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Data
{
    public sealed class DataRelationEdge 
        : IEdge<DataTable>
    {
        private readonly DataRelation relation;
        public DataRelationEdge(DataRelation relation)
        {
#if CTR
            Contract.Requires(relation != null);
#endif

            this.relation = relation;
        }

        public DataRelation Relation
        {
            get { return this.relation; }
        }

        public DataTable Source
        {
            get { return this.relation.ParentTable;}
        }

        public DataTable Target
        {
            get { return this.relation.ChildTable; }
        }
    }
}
