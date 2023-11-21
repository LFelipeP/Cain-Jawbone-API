using cain_jawbone_domains;
using System.Linq.Expressions;

namespace Cain.Jawbone.Infra.Data.Contexts.Interfaces
{
    public interface ICosmosDbContext<TModel> where TModel : ModelBase
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> ReadAsync(Guid id);
        Task<TModel> UpdateAsync(Guid id, TModel item);
        Task<TModel> DeleteAsync(Guid id);
        IQueryable<TModel> QueryAsync();
        IQueryable<TModel> FindAsync(Expression<Func<TModel, bool>> expression);
    }
}
