using EnterpriseLayers.Contract.DataAccess;

namespace EnterpriseLayers.Web.Controllers {
	public class UnitOfWorkController : BaseController {
		public IUnitOfWork UnitOfWork { get; private set; }

		public UnitOfWorkController(IUnitOfWork uow) {
			UnitOfWork = uow;
		}
	}
}