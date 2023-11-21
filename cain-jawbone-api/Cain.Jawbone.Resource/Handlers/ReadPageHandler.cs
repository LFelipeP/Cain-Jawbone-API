using Cain.Jawbone.Domain.Interfaces;
using cain_jawbone_resources.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace cain_jawbone_resources.Handlers
{
    public class ReadPageHandler : IRequestHandler<ReadPageCommand, PageResult>
    {
        private readonly IPageRepository _repository;
        private readonly ILogger<ReadPageHandler> _logger;

        public ReadPageHandler(IPageRepository repository, ILogger<ReadPageHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PageResult> Handle(ReadPageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var queryResult = _repository.FindAsync(x => x.PageNumber == request.PageNumber).ToList();

                var page = queryResult.FirstOrDefault();

                if (page == null)
                    return new PageResult("Página não encontrada");

                return new PageResult(page);
            }
            catch(CosmosException ex)
            {
                return new PageResult("Página não encontrada");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading page: {pageNumber}, Exception: {Message}", request.PageNumber, ex.Message);

                return new PageResult("Erro ao buscar página, tente novamente mais tarde");
            }
        }
    }
}
