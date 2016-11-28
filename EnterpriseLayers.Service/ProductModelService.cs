using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseLayers.Service {
	/// <summary>
	/// Service method with full architecture including dependency injection
	/// </summary>
	public class ProductModelService : IProductModelService {
		private IRepository<ProductModel> _productModelRepo;
		private IRepository<Illustration> _illustrationRepo;

		/**
		 * Without DI
		 * */
		//public ProductModelService(IUnitOfWork uow) : base(uow) {
		//	_productModelRepository = new GenericRepository<ProductModel>(uow);
		//	_illustrationRepository = new GenericRepository<Illustration>(uow);
		//}

		/**
		 * With DI
		 * */
		public ProductModelService(
			IRepository<ProductModel> productModelRepo, 
			IRepository<Illustration> illustrationRepo) {
			_productModelRepo = productModelRepo;
			_illustrationRepo = illustrationRepo;
		}

		public List<IllustrationModel> GetIllustrationsByProductModel(int productModelID) {
			//query from Illustration side
			var illusData = _illustrationRepo
				.Get(x => x.ProductModels)
				.Where(x => x.ProductModels.Select(y => y.ProductModelID == productModelID).FirstOrDefault())
				.ToList();
			var model = illusData.To<List<IllustrationModel>>();
			return model;

			//...from ProductModel side
			//var data = _productModelRepository
			//	.Get(x => x.Illustrations)
			//	.FirstOrDefault(pm => pm.ProductModelID == productModelID);
			//return data.Illustrations.ToList();
		}
	}
}
