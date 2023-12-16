using ECommerceProject.Application.Repository.Interface;
using ECommerceProject.Domain.Entities.Base;
using ECommerceProject.Domain.Enums;
using ECommerceProject.Persistence.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Persistence.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPPIDbContext _context;

        public ReadRepository(ECommerceAPPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression is null ? GetAllActives().AnyAsync() : GetAllActives().AnyAsync(expression);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task<IExecutionStrategy> CreateExecutionStrategy()
        {
            return Task.FromResult(_context.Database.CreateExecutionStrategy());
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool tracking = false)
        {
            return await GetAllActives(tracking).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool tracking = false)
        {
            return await GetAllActives(tracking).Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, double>> orderby, bool orderDesc = false, bool tracking = true)
        {
            var values = GetAllActives(tracking);
            return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
        }
        public IQueryable<T> GetProductByPageSize(bool tracking = false)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, Expression<Func<T, double>> orderBy, bool orderDesc = false, bool tracking = true)
        {
            var values = GetAllActives(tracking).Where(expression);
            return orderDesc ? await values.OrderByDescending(orderBy).ToListAsync() : await values.OrderBy(orderBy).ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>>? expression, bool tracking = true)
        {
            return await GetAllActives(tracking).FirstOrDefaultAsync(expression);
        }

        public async Task<T?> GetByIdAsync(Guid? id, bool tracking = true)
        {
            return await GetAllActives(tracking).FirstOrDefaultAsync(x => x.Id == id);
        }
        protected IQueryable<T> GetAllActives(bool tracking = true)
        {
            var values = Table.Where(x => x.Status != Status.Deleted);
            return tracking ? values : values.AsNoTracking(); 
        }

    }
}
