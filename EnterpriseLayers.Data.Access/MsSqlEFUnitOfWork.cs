using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Data.Context;
using System.Data.Entity;

namespace EnterpriseLayers.Data.Access {
	public class MsSqlEFUnitOfWork : IUnitOfWork {
		public DbContext Context { get; private set; }

		public MsSqlEFUnitOfWork() {
			Context = new MsSqlEFContext();
		}

		public void SaveChanges() {
			Context.SaveChanges();
		}

		public void Dispose() {
			Context.Dispose();
		}
	}
}
