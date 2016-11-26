using EnterpriseLayers.Contract.Service;
using System.Web.Mvc;

namespace EnterpriseLayers.Web.Controllers {
	public class ProductModelController : Controller /*: UnitOfWorkController*/ {
		private IProductModelService _productModelService;

		/**
		 * Services without DI
		 * */
		//public ProductModelController(IUnitOfWork uow) : base(uow) {
		//	_productModelService = new ProductModelService(this.UnitOfWork);
		//}

		/**
		 * Services with DI
		 * */
		public ProductModelController(IProductModelService productModelService) {
			_productModelService = productModelService;
		}

		// GET: ProductModel
		public ActionResult Index() {
			//Manually call UoW with no DI
			//List<Illustration> model = null;
			//using (var uow = UnitOfWorkFactory.Create("MsSqlEF")) {
			//	//get services
			//	var productModelService = new ProductModelService(uow);
			//	model = productModelService.GetIllustrationsByProductModel(47);
			//	//uow.SaveChanges();
			//}

			//Utilize injected UoW from base controller class
			var model = _productModelService.GetIllustrationsByProductModel(47);
			return View(model);
		}
	}
}