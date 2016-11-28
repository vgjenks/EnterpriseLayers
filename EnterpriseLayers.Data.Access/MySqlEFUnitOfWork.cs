using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Data.Context;
using EnterpriseLayers.Exception;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace EnterpriseLayers.Data.Access {
	public class MySqlEFUnitOfWork : IUnitOfWork {
		public DbContext Context { get; private set; }

		public MySqlEFUnitOfWork() {
			Context = new MySqlEFContext();
		}

		public void SaveChanges() {
			try {
				Context.SaveChanges();
			} catch (DbEntityValidationException ex) {
				throw new DataException(ex);
			}
		}

		public void Dispose() {
			Context.Dispose();
		}
	}
}
