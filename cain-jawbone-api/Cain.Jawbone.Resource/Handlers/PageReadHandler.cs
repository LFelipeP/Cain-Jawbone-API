using cain_jawbone_domains.Interfaces;
using cain_jawbone_resources.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace cain_jawbone_resources.Handlers
{
    public class PageReadHandler : IRequestHandler<PageReadCommand, PageReadResult>
    {
        private readonly IPageRepository _repository;
        private readonly ILogger<PageReadHandler> _logger;

        public PageReadHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<PageReadResult> Handle(PageReadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var queryResult = _repository.FindAsync(x => x.PageNumber == request.PageNumber).ToList();

                var page = queryResult.FirstOrDefault();

                if (page == null)
                    return new PageReadResult("Página não encontrada");

                return new PageReadResult(page);

            }
            catch (Exception ex) 
            {
                _logger.LogError("Error reading page: {pageNumber}, Exception: {Message}", request.PageNumber, ex.Message);

                return new PageReadResult("Erro ao buscar página, tente novamente mais tarde");
            }
        }
    }
}
