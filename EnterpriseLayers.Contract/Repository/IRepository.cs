using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Contract.Repository {
	public interface IRepository<TEntity> where TEntity : class {
		IQueryable<TEntity> All { get; }
		IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes);
		IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>,
			IOrderedQueryable<TEntity>> orderBy = null,
			int? page = null,
			int? pageSize = null,
			params Expression<Func<TEntity, object>>[] includes);
		TEntity Find(object id);

		//DbRawSqlQuery<T> GetRawQuery<T>(string sql, object[] parameters = null);
		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(object id);
		void Delete(TEntity entity);
		//IQueryable<TEntity> Get(object filter);
		//void SaveChanges();
		//void Dispose();
	}
}
