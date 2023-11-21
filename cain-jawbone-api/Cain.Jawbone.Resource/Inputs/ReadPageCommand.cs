using Cain.Jawbone.Domain;
using cain_jawbone_resources.Results;
using MediatR;

namespace cain_jawbone_resources.Inputs
{
    public class ReadPageCommand : IRequest<PageResult>
    {
        public ReadPageCommand(int pageNumber) 
        { 
            PageNumber = pageNumber;
        }        
        public int PageNumber { get; set; }
    }
}
