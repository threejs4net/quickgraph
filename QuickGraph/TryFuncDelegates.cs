#if CTR        
using System.Diagnostics.Contracts;
#endif

namespace QuickGraph
{
#if CTR        
  [Pure]
#endif
  public delegate bool TryFunc<T, TResult>(T arg, out TResult result);
#if CTR        
  [Pure]
#endif
  public delegate bool TryFunc<T1, T2, TResult>(T1 arg, T2 arg2, out TResult result);
#if CTR        
  [Pure]
#endif
  public delegate bool TryFunc<T1, T2, T3, TResult>(T1 arg, T2 arg2, T3 arg3, out TResult result);
#if CTR        
  [Pure]
#endif
  public delegate bool TryFunc<T1, T2, T3, T4, TResult>(T1 arg, T2 arg2, T3 arg3, T4 arg4, out TResult result);
}
