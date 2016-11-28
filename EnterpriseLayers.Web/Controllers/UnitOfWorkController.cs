using EnterpriseLayers.Contract.DataAccess;

namespace EnterpriseLayers.Web.Controllers {
	/// <summary>
	/// Base controller for UoW use without dependency injection
	/// </summary>
	public abstract class UnitOfWorkController : BaseController {
		public IUnitOfWork UnitOfWork { get; private set; }

		public UnitOfWorkController(IUnitOfWork uow) {
			UnitOfWork = uow;
		}
	}
}