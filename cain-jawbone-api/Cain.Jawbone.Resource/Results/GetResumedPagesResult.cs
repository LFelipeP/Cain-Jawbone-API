using Cain.Jawbone.Resource.Models;

namespace cain_jawbone_resources.Results
{
    public class GetResumedPagesResult : AbstractCommandResult<List<ResumedPage>>
    {
        public GetResumedPagesResult() : base() { }
        public GetResumedPagesResult(string message) : base(message) { }
        public GetResumedPagesResult(List<ResumedPage> pages) : base(pages, true) { }
    }
}
