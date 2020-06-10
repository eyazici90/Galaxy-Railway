using System.Collections.Generic;

namespace Galaxy.Railway
{
    public class ExecutionResult : IExecutionResult
    {
        public static ExecutionResult Success = new SuccessExecutionResult(); 
        public static ExecutionResult Failed = new FailedExecutionResult();
        public static ExecutionResult Fail(IEnumerable<string> errors) => new ExecutionResult(false, errors);
        public static ExecutionResult Fail(params string[] errors) => new ExecutionResult(false, errors);
        public bool IsSuccess { get; }
        public IEnumerable<string> Errors { get; }
        protected ExecutionResult(bool isSuccess, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public override string ToString() => $"ExecutionResult - IsSuccess:{IsSuccess}";

    }
}
