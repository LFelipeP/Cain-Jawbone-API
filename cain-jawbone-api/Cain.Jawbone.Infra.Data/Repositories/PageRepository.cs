using Cain.Jawbone.Infra.Data.Contexts.Interfaces;
using cain_jawbone_domains;
using cain_jawbone_domains.Interfaces;
using System.Linq.Expressions;

namespace Cain.Jawbone.Infra.Data.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly IPageContext _context;
        public PageRepository(IPageContext context)
        {
            _context = context;
        }

        public Task<Page> CreateAsync(Page model)
        {
            return _context.CreateAsync(model);
        }
        public Task<Page> ReadAsync(Guid id)
        {
            return _context.ReadAsync(id);
        }
        public Task<List<Page>> QueryAsync()
        {
            return Task.FromResult(_context.QueryAsync().ToList());
        }
        public Task<Page> UpdateAsync(Guid id, Page model)
        {
            return _context.UpdateAsync(id, model);
        }

        public Task<Page> DeleteAsync(Guid id)
        {
            return _context.DeleteAsync(id);
        }

        public IQueryable<Page> FindAsync(Expression<Func<Page, bool>> expression)
        {
            return _context.FindAsync(expression);
        }
    }
}
