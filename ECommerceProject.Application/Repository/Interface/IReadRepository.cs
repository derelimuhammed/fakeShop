using ECommerceProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Repository.Interface
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null);
        Task<T?> GetByIdAsync(Guid? id, bool tracking = true);
        Task<T?> GetAsync(Expression<Func<T, bool>>? expression, bool tracking = true);
        Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, double>> orderby, bool orderDesc = false, bool tracking = true);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, Expression<Func<T, double>> orderBy, bool orderDesc = false, bool tracking = true);
        public IQueryable<T> GetProductByPageSize(bool tracking = false);
    }
}
