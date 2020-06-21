using System;

namespace Galaxy.Railway.Examples
{
    public class Example3
    {
        private readonly Func<string, Optional<string>> _get;
        private readonly Action<string> _send;
        //

        public IExecutionResult Run(string identifer)
        {
            var resut = _get(identifer);
            if (!resut.HasValue)
            {
                throw new ArgumentNullException();
            }
            var @obj = resut.Value;

            var toLower = obj.ToLower();

            _send(toLower);

            return ExecutionResult.Success;
        }

        public IExecutionResult RunFunc(string identifer) =>
            _get(identifer)
            .ThrowsIf(result => !result.HasValue, new ArgumentNullException())
            .Map(result => result.Value.ToLower())
            .AndThen(_send)
            .Map(_ => ExecutionResult.Success);
    }
}
