using Cain.Jawbone.Domain;
using Cain.Jawbone.Domain.Interfaces;
using Cain.Jawbone.Resource.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace cain_jawbone_resources.Handlers
{
    public class UpdatePageHandler : IRequestHandler<UpdatePageCommand, PageResult>
    {
        private readonly IPageRepository _repository;
        private readonly ILogger<UpdatePageHandler> _logger;

        public UpdatePageHandler(IPageRepository repository, ILogger<UpdatePageHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PageResult> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var verifyPage = await _repository.ReadAsync(request.Content.Id);

                if (verifyPage.PageNumber != request.Content.PageNumber)
                    return new PageResult($"O número da página não pode ser alterado, tente criar uma nova página");

                var result = await _repository.UpdateAsync(request.Content.Id,
                    new Page
                    {
                         Id = request.Content.Id,
                         PageNumber = request.Content.PageNumber,
                         Title = request.Content.Title,
                         Characters = request.Content.Characters,
                         Tags = request.Content.Tags,
                         Order = request.Content.Order,
                         CreationUser = verifyPage.CreationUser,
                         CreationDate = verifyPage.CreationDate,
                    }
                );

                if (result == null)
                    return new PageResult("Não foi possível atualizar Página");

                return new PageResult(result);
            }
            catch (CosmosException ex)
            {
                _logger.LogError("Error updating page: {pageNumber}, Exception: {Message}", request.Content.PageNumber, ex.Message);
                return new PageResult("Não foi possível atualizar Página");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating page: {pageNumber}, Exception: {Message}", request.Content.PageNumber, ex.Message);
                return new PageResult("Erro ao atualizar página, tente novamente mais tarde");
            }
        }
    }
}
