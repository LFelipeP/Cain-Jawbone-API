namespace cain_jawbone_resources.Results
{
    public abstract class AbstractCommandResult<T> where T : class
    {
        public AbstractCommandResult() 
        {
            Success = true;
        }

        public AbstractCommandResult(T data, bool success)
        {
            Data = data;
            Success = true;
        }

        public AbstractCommandResult(string error)
        {
            Message = error;
            Success = false;
        }

        public T Data { get; }
        public string Message { get; }
        public bool Success { get; }
    }
}
