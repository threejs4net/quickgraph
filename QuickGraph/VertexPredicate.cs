using System;
#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if CTR
    [Pure]
#endif
    public delegate bool VertexPredicate<TVertex>(TVertex v);
}
