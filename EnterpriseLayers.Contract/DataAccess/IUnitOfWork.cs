using System;
using System.Data.Entity;

namespace EnterpriseLayers.Contract.DataAccess {
	public interface IUnitOfWork : IDisposable {
		DbContext Context { get; }
		//IDbCommand CreateCommand();
		void SaveChanges();
		new void Dispose();
	}
}
