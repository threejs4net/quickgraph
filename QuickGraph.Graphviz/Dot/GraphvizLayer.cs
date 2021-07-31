namespace QuickGraph.Graphviz.Dot
{
    using System;
#if CTR
    using System.Diagnostics.Contracts;
#endif

    public class GraphvizLayer
    {
        private string name;

        public GraphvizLayer(string name)
        {
#if CTR
            Contract.Requires(!String.IsNullOrEmpty(name));
#endif            
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
#if CTR
                Contract.Requires(!String.IsNullOrEmpty(value));
#endif
                this.name = value;
            }
        }
    }
}

