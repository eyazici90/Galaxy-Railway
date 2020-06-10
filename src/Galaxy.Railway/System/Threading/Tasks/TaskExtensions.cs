using System.Runtime.CompilerServices;

namespace System.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static ConfiguredTaskAwaitable ConfigureAwaitFalse(this Task @this) =>
          @this.ConfigureAwait(false);

        public static ConfiguredTaskAwaitable<T> ConfigureAwaitFalse<T>(this Task<T> @this) =>
          @this.ConfigureAwait(false);
    }
}
