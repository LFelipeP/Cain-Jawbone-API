using Cain.Jawbone.Domain.Interfaces;
using Cain.Jawbone.Resource.Models;
using cain_jawbone_resources.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace cain_jawbone_resources.Handlers
{
    public class GetResumedPagesHandler : IRequestHandler<GetResumedPagesCommand, GetResumedPagesResult>
    {
        private readonly IPageRepository _repository;
        private readonly ILogger<GetResumedPagesHandler> _logger;

        public GetResumedPagesHandler(IPageRepository repository, ILogger<GetResumedPagesHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetResumedPagesResult> Handle(GetResumedPagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var queryResult = await _repository.QueryAsync();

                var result = queryResult.Select(x => new ResumedPage
                {
                    id = x.Id,
                    Order = x.Order,
                    PageNumber = x.PageNumber,
                    Title = x.Title,
                    UpdateDate = x.UpdateDate,
                }).OrderBy(x => x.PageNumber).ToList();

                return new GetResumedPagesResult(result);
            }
            catch (CosmosException ex)
            {
                _logger.LogError("Error reading pages: Exception: {Message}", ex.Message);

                return new GetResumedPagesResult("Não foi possível recuperar páginas");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading pages: Exception: {Message}", ex.Message);

                return new GetResumedPagesResult("Não foi possível recuperar páginas");
            }
        }
    }
}
