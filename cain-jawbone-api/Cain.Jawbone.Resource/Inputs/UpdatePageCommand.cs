using Cain.Jawbone.Domain;
using Cain.Jawbone.Resource.Models;
using cain_jawbone_resources.Results;
using MediatR;

namespace Cain.Jawbone.Resource.Inputs
{
    public class UpdatePageCommand : IRequest<PageResult>
    {
        public UpdatePageCommand(PageModel page)
        {
            Content = new Page
            {
                Id = page.id,
                PageNumber = page.PageNumber,
                Title = page.Title,
                Characters = page.Characters,
                Tags = page.Tags,
                Order = page.Order
            };
        }

        public Page Content { get; set; }
    }
}
