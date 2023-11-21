using System.Linq.Expressions;

namespace cain_jawbone_domains.Interfaces
{
    public interface IRepository<TModel> where TModel : ModelBase
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> ReadAsync(Guid id);
        Task<TModel> UpdateAsync(Guid id, TModel model);
        Task<TModel> DeleteAsync(Guid id);
        Task<List<TModel>> QueryAsync();
        IQueryable<TModel> FindAsync(Expression<Func<TModel, bool>> expression);
    }
}
