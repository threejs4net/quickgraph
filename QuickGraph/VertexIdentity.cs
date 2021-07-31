#if CTR
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if CTR
    [Pure]
#endif
    public delegate string VertexIdentity<TVertex>(TVertex v);
}
