using ECommerceProject.Application.Repository.Interface;
using ECommerceProject.Domain.Entities.Base;
using ECommerceProject.Persistence.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Persistence.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPPIDbContext _context;

        public WriteRepository(ECommerceAPPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            var entry = await Table.AddAsync(entity);  //AddAsync, DBContext ten gelen default bir metottur, bizim yaptığımız birşey değil
            return entry.Entity;
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            return Table.AddRangeAsync(entities);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task<IExecutionStrategy> CreateExecutionStrategy()
        {
            return Task.FromResult(_context.Database.CreateExecutionStrategy());
        }

        public Task DeleteAsync(T entity)
        {
            return Task.FromResult(Table.Remove(entity));
        }

        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
            return _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = await Task.FromResult(Table.Update(entity));
            return entry.Entity;
        }
    }
}
