using cain_jawbone_domains;
using cain_jawbone_resources.Results;
using MediatR;

namespace cain_jawbone_resources.Inputs
{
    public class PageReadCommand : IRequest<PageReadResult>
    {
        public PageReadCommand(int pageNumber) 
        { 
            PageNumber = pageNumber;
        }        
        public int PageNumber { get; set; }
    }
}
