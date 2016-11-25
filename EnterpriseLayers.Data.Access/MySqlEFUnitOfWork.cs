using System;
using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Data.Context;
using System.Data.Entity;

namespace EnterpriseLayers.Data.Access {
	public class MySqlEFUnitOfWork : IUnitOfWork {
		public DbContext Context { get; private set; }

		public MySqlEFUnitOfWork() {
			Context = new MySqlEFContext();
		}

		public void Dispose() {
			Context.SaveChanges();
		}

		public void SaveChanges() {
			Context.Dispose();
		}
	}
}
