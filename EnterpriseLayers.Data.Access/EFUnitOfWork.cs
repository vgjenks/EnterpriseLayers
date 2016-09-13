using EnterpriseLayers.Contract.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EnterpriseLayers.Data.Context;

namespace EnterpriseLayers.Data.Access {
	public class EFUnitOfWork : IUnitOfWork {
		public IDbContext Context { get; private set; }

		public EFUnitOfWork() {
			Context = new EnterpriseLayersContext();
		}

		public void SaveChanges() {
			Context.SaveChanges();
		}

		public void Dispose() {
			Context.Dispose();
		}
	}
}
