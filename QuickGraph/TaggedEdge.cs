﻿using System;

#if CTR        
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if !SILVERLIGHT
	[Serializable]
#endif
    public class TaggedEdge<TVertex,TTag> 
        : Edge<TVertex>
        , ITagged<TTag>
    {
        private TTag tag;

        public TaggedEdge(TVertex source, TVertex target, TTag tag)
            :base(source,target)
        {
#if CTR        
            Contract.Ensures(Object.Equals(this.Tag,tag));
#endif

            this.tag = tag;
        }

        public event EventHandler TagChanged;

        protected virtual void OnTagChanged(EventArgs e)
        {
            var eh = this.TagChanged;
            if (eh != null)
                eh(this, e);
        }

        public TTag Tag
        {
            get { return this.tag; }
            set 
            {
                if (!object.Equals(this.tag, value))
                {
                    this.tag = value;
                    this.OnTagChanged(EventArgs.Empty);
                }
            }
        }
    }
}
