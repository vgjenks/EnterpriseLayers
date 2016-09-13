using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Contract.DataAccess {
	public interface IUnitOfWork : IDisposable {
		IDbContext Context { get; }
		//IDbCommand CreateCommand();
		void SaveChanges();
		void Dispose();
    }
}
