using System;
using System.Collections.Generic;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph.Predicates
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public sealed class InDictionaryVertexPredicate<TVertex, TValue>
    {
        private readonly IDictionary<TVertex, TValue> dictionary;

        public InDictionaryVertexPredicate(
            IDictionary<TVertex,TValue> dictionary)
        {
#if CTR
            Contract.Requires(dictionary != null);
#endif
            this.dictionary = dictionary;
        }

#if CTR        
        [Pure]
#endif
        public bool Test(TVertex v)
        {
#if CTR
            Contract.Requires(v != null);
#endif
            return this.dictionary.ContainsKey(v);
        }
    }
}
