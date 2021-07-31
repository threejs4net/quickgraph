#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if CTR
    [Pure]
#endif
    public delegate int VertexIndexer<TVertex>(TVertex v);
}
