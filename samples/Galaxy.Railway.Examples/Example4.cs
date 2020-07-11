using System; 
using System.Threading.Tasks;

namespace Galaxy.Railway.Examples
{
    public class Example4
    {
        private readonly Func<string, Task<Optional<string>>> _get;
        private readonly Func<string, Task> _send;
        //

        public async Task<IExecutionResult> Run(string identifer)
        {
            var resut = await _get(identifer);
            if (!resut.HasValue)
            {
                throw new ArgumentNullException();
            }
            var @obj = resut.Value; 
            var toLower = obj.ToLower(); 
            await _send(toLower); 
            return ExecutionResult.Success;
        }

        public async Task<IExecutionResult> RunFunc(string identifer) =>
           await _get(identifer)
            .ThrowsIfAsync(result => !result.HasValue, new ArgumentNullException())
            .MapAsync(result => result.Value.ToLower())
            .AndThenAsync(_send)
            .MapAsync(_ => ExecutionResult.Success);
    }
}
