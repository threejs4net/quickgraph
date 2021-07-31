using System;
using System.Collections.Generic;
using System.Text;
#if CTR
using System.Diagnostics.Contracts;
#endif
namespace QuickGraph.Graphviz.Dot
{
    public sealed class GraphvizFont
    {
        readonly string name;
        readonly float sizeInPoints;

        public string Name { get { return this.name; } }
        public float SizeInPoints { get { return this.sizeInPoints; } }

        public GraphvizFont(string name, float sizeInPoints)
        {
#if CTR
            Contract.Requires(!String.IsNullOrEmpty(name));
            Contract.Requires(sizeInPoints > 0);
#endif
            this.name = name;
            this.sizeInPoints = sizeInPoints;
        }
    }
}
