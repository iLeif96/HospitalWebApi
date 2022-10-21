using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;

using Hospital.Application.Interfaces.Repositories;
using Hospital.Application.Models;
using Hospital.Domain.Common;
using Hospital.Domain.Enum;
using Hospital.Infrastructure.Databases;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class GenericRepositoryEF<TEntity> : IGenericRepository<TEntity> where TEntity : DbEntityBase
    {
        protected HospitalContext _context;
        protected DbSet<TEntity> _table;

        public GenericRepositoryEF(HospitalContext hospitalContext)
        {
            _context = hospitalContext;
            _table = hospitalContext.Set<TEntity>();
        }

        public virtual TEntity? FindById(long id, bool isUseTracking = false, bool isNeedToUseInclude = true)
        {
            var query = isUseTracking ? _table.AsQueryable() : _table.AsNoTracking();

            if (isNeedToUseInclude)
            {
                query = IncludeMembers(query);
            }

            return query.FirstOrDefault(record => record.Id == id);
        }

        public virtual async Task<TEntity?> FindByIdAsync(long id, bool isUseTracking = false, bool isNeedToUseInclude = true)
        {
            var query = isUseTracking ? _table.AsQueryable() : _table.AsNoTracking();

            if (isNeedToUseInclude)
            {
                query = IncludeMembers(query);
            }

            return await query.FirstOrDefaultAsync(record => record.Id == id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(bool isUseTracking = false, bool isNeedToUseInclude = true)
        {
            var query = isUseTracking ? _table.AsQueryable() : _table.AsNoTracking();

            if (isNeedToUseInclude)
            {
                query = IncludeMembers(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetPageAsync(PaginationOptions options, bool isNeedToUseInclude = true)
        {
            Page page = options.Page;

            var query = _table.AsQueryable();//AsNoTracking();
            if (isNeedToUseInclude)
            {
                query = IncludeMembers(query);
            }

            query = GetPageQuery(query, page);
            query = GetOrderQuery(query, options.SortOrder, options.OrderColumnName);

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity model)
        {
            await _table.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity model)
        {
            _table.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            TEntity? record = await _table.FirstOrDefaultAsync(record => record.Id == id);

            if (record == null)
            {
                return false;
            }

            _table.Remove(record);

            int changesCount = await _context.SaveChangesAsync();
            return changesCount > 0;
        }

        protected virtual IQueryable<TEntity> GetPageQuery(IQueryable<TEntity> query, Page page)
        {
            if (query == null)
            {
                return query;
            }

            return query.Skip(page.FirstRow()).Take(page.PageSize);
        }

        protected virtual IQueryable<TEntity> GetOrderQuery(IQueryable<TEntity> query, SortOrder sortOrder, string orderColumnName)
        {
            if (sortOrder != SortOrder.NONE && !string.IsNullOrEmpty(orderColumnName))
            {
                string order = sortOrder.ToString().ToUpper();
                try
                {
                    query = query.OrderBy(orderColumnName + " " + order);
                }
                catch
                {

                }
            }

            return query;
        }

        protected virtual IQueryable<TEntity> IncludeMembers(IQueryable<TEntity>? query = null)
        {
            if (query != null)
            {
                return query;
            }

            return _table.AsQueryable<TEntity>();
        }
    }
}
