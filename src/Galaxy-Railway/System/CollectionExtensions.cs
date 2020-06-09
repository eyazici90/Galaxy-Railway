using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source) => source == null || source.Count <= 0;

        public static void ForEach<T>(this IEnumerable<T> @objList, Action<T> act)
        {
            foreach (var @obj in @objList)
            {
                act(@obj);
            }
        }
        public static void ForEach<T>(this IReadOnlyCollection<T> @objList, Action<T> act) => objList.AsEnumerable().ForEach(act);

        public static void ForEach<T>(this T[] @objList, Action<T> act)
        {
            foreach (var @obj in @objList)
            {
                act(@obj);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> @objList,
          Func<T, Task> func)
        {
            foreach (var doc in @objList)
            {
                await func(doc).ConfigureAwait(false);
            }
        }

        public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(this Task<List<T>> source,
           Func<T, TResult> select) =>
           (await source.ConfigureAwait(false)).Select(select);

        public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(this Task<IEnumerable<T>> source,
           Func<T, TResult> select) =>
           (await source.ConfigureAwait(false)).Select(select);

        public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(this Task<ICollection<T>> source,
        Func<T, TResult> select) =>
           (await source.ConfigureAwait(false)).Select(select);

        public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(this Task<IReadOnlyCollection<T>> source,
        Func<T, TResult> select) =>
          (await source.ConfigureAwait(false)).Select(select);

        public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(this Task<IList<T>> source,
           Func<T, TResult> select) =>
           (await source.ConfigureAwait(false)).Select(select);
    }
}
