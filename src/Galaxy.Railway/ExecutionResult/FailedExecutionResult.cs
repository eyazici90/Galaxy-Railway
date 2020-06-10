using System.Collections.Generic; 

namespace Galaxy.Railway
{
    public class FailedExecutionResult : ExecutionResult
    {
        public FailedExecutionResult() : base(false, null)
        {
        }
        public FailedExecutionResult(IEnumerable<string> errors) : base(false, errors)
        {
        }
    }
}
