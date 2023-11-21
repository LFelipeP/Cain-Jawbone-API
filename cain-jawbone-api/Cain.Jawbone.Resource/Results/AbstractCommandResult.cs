namespace cain_jawbone_resources.Results
{
    public abstract class AbstractCommandResult
    {
        public AbstractCommandResult() 
        {
            Success = true;
        }

        public AbstractCommandResult(object data, bool success)
        {
            Data = data;
            Success = true;
        }

        public AbstractCommandResult(string error)
        {
            Message = error;
            Success = false;
        }

        public object Data { get; }
        public string Message { get; }
        public bool Success { get; }
    }
}
