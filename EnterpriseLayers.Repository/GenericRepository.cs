using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Contract.DataAccess;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EnterpriseLayers.Repository {
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class {
		internal DbContext _dbContext;
		internal DbSet<TEntity> _dbSet;

		public GenericRepository(IUnitOfWork unitOfWork) {
			_dbContext = unitOfWork.Context;
			_dbSet = _dbContext.Set<TEntity>();
		}

		public virtual IQueryable<TEntity> All {
			get {
				return _dbSet;
			}
		}

		public virtual TEntity Find(object id) {
			return _dbSet.Find(id);
		}

		public virtual IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes) {
			return includes.Aggregate<Expression<Func<TEntity, object>>,
				IQueryable<TEntity>>(_dbSet, (current, expression) => current.Include(expression));
		}

		public virtual IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null, 
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
			int? page = default(int?), 
			int? pageSize = default(int?),
			params Expression<Func<TEntity, object>>[] includes) {

			IQueryable<TEntity> query = _dbSet;

			query = includes.Aggregate<Expression<Func<TEntity, object>>,
				IQueryable<TEntity>>(_dbSet, (current, expression) => current.Include(expression));

			if (filter != null) {
				query = query.Where(filter);
			}

			if (orderBy != null) {
				query = orderBy(query);
			}

			if (page != null && pageSize != null) {
				query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
			}

			return query;
		}

		//public DbRawSqlQuery<T> GetRawQuery<T>(string sql, object[] parameters = null) {
		//	return _dbContext.Database.SqlQuery<T>(sql, parameters);
		//}

		public virtual void Insert(TEntity entity) {
			_dbSet.Add(entity);
		}

		public virtual void Update(TEntity entity) {
			_dbSet.Attach(entity);
			_dbContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(TEntity entity) {
			if (_dbContext.Entry(entity).State == EntityState.Detached) {
				_dbSet.Attach(entity);
			}
			_dbSet.Remove(entity);
		}

		public virtual void Delete(object id) {
			TEntity entityToDelete = _dbSet.Find(id);
			Delete(entityToDelete);
		}
	}
}
