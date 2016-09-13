using EnterpriseLayers.Contract.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Data.Access {
	public class UnitOfWorkFactory {
		public static IUnitOfWork Create() {
			/**
			 * Conditional logic here to choose which UoW
			 * implementation to return (ADO, EF, etc.)
			 * 
			 * ...but for now:
			 **/
			return new EFUnitOfWork();
		}
	}
}
