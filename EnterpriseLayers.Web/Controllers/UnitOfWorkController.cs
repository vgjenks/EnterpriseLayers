using EnterpriseLayers.Contract.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseLayers.Web.Controllers {
	public class UnitOfWorkController : BaseController {
		public IUnitOfWork UnitOfWork { get; private set; }

		public UnitOfWorkController(IUnitOfWork uow) {
			UnitOfWork = uow;
		}
	}
}