using System.Threading.Tasks;

namespace Galaxy_Railway.Threading
{
    public static class TaskCache
    {
        public static Task<bool> TrueResult { get; }
        public static Task<bool> FalseResult { get; }
        public static Task Completed { get; }

        static TaskCache()
        {
            TrueResult = Task.FromResult(true);
            FalseResult = Task.FromResult(false);
            Completed = Task.CompletedTask;
        }
    }
}
