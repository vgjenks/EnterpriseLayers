using EnterpriseLayers.Contract.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Service {
	public abstract class BaseService {
		public BaseService(IUnitOfWork uow) {
			if (uow == null)
				throw new ArgumentNullException("Missing Unit of Work Implementation");
		}
	}
}
