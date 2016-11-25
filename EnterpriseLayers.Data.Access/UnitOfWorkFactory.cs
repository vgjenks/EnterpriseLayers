using EnterpriseLayers.Contract.DataAccess;
using System;

namespace EnterpriseLayers.Data.Access {
	public class UnitOfWorkFactory {
		public IUnitOfWork UnitOfWork { get; set; }

		public UnitOfWorkFactory(string databasePlatform) {
			UnitOfWork = Create(databasePlatform);
		}

		public static IUnitOfWork Create(string databasePlatform) {
			/**
			 * Conditional logic to choose which UoW
			 * implementation to return (ADO, EF, etc.)
			 **/
			IUnitOfWork uow = null;
			switch (databasePlatform) {
				case "MsSqlEF":
					uow = new MsSqlEFUnitOfWork();
					break;
				case "MySqlEF":
					uow = new MySqlEFUnitOfWork();
					break;
				default:
					throw new InvalidOperationException(
						"ERROR: You must provide a valid database platform argument to invoke a new Unit of Work.");
			}
			return uow;
		}
	}
}
