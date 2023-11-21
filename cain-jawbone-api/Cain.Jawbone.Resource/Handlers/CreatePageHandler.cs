using Cain.Jawbone.Domain.Interfaces;
using Cain.Jawbone.Resource.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace cain_jawbone_resources.Handlers
{
    public class CreatePageHandler : IRequestHandler<CreatePageCommand, PageResult>
    {
        private readonly IPageRepository _repository;
        private readonly ILogger<CreatePageHandler> _logger;

        public CreatePageHandler(IPageRepository repository, ILogger<CreatePageHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PageResult> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var verifyPageNumber = _repository.FindAsync(x => x.PageNumber == request.Content.PageNumber).ToList().Any();

                if(verifyPageNumber)
                    return new PageResult($"A Página número {request.Content.PageNumber} já foi cadastrada");

                var result = await _repository.CreateAsync(request.Content);               

                if (result == null)
                    return new PageResult("Não foi possível criar Página");

                return new PageResult(result);
            }
            catch (CosmosException ex)
            {
                _logger.LogError("Error creating page: {pageNumber}, Exception: {Message}", request.Content.PageNumber, ex.Message);
                return new PageResult("Não foi possível criar Página");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating page: {pageNumber}, Exception: {Message}", request.Content.PageNumber, ex.Message);
                return new PageResult("Erro ao criar página, tente novamente mais tarde");
            }
        }
    }
}
