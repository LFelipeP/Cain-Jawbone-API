using Cain.Jawbone.Domain;
using Cain.Jawbone.Resource.Models;

namespace cain_jawbone_resources.Results
{
    public class PageResult : AbstractCommandResult<PageModel>
    {
        public PageResult() : base() { }
        public PageResult(string message) : base(message) { }
        public PageResult(Page page) : base(new PageModel(page), true) { }
    }
}
