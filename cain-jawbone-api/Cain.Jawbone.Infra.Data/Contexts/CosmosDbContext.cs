using Cain.Jawbone.Infra.Data.Contexts.Interfaces;
using cain_jawbone_domains;
using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Cain.Jawbone.Infra.Data.Contexts
{
    public class CosmosDbContext<TModel> : ICosmosDbContext<TModel> where TModel : ModelBase
    {

        protected readonly Container Container;

        public CosmosDbContext(Container container)
        {
            Container = container;
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreationDate = DateTime.Now;
            var response = await Container.CreateItemAsync(model, new PartitionKey(model.Id.ToString()));
            return response.Resource;
        }

        public async Task<TModel> ReadAsync(Guid id)
        {
            ItemResponse<TModel> response = await Container.ReadItemAsync<TModel>(id.ToString(), new PartitionKey(id.ToString()));
            return response.Resource;
        }

        public async Task<TModel> UpdateAsync(Guid id, TModel item)
        {
            item.UpdateDate = DateTime.Now;
            var response = await Container.UpsertItemAsync(item, new PartitionKey(id.ToString()));
            return response.Resource;
        }

        public async Task<TModel> DeleteAsync(Guid id)
        {
            var response = await Container.DeleteItemAsync<TModel>(id.ToString(), new PartitionKey(id.ToString()));
            return response.Resource;
        }

        public IQueryable<TModel> QueryAsync()
        {
            var query = Container.GetItemLinqQueryable<TModel>(true);

            return query;
        }

        public IQueryable<TModel> FindAsync(Expression<Func<TModel, bool>> expression)
        {
            var query = Container.GetItemLinqQueryable<TModel>(true).AsQueryable();

            query = query.Where(expression);

            return query;
        }
    }
}

