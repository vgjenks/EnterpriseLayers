using AutoMapper;
using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseLayers.Service {
	public class ProductModelService : BaseService, IProductModelService {
		private IRepository<ProductModel> _productModelRepository;
		private IRepository<Illustration> _illustrationRepository;

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
			IUnitOfWork uow, 
			IRepository<ProductModel> productModelRepository, 
			IRepository<Illustration> illustrationRepository) : base(uow) {
			_productModelRepository = productModelRepository;
			_illustrationRepository = illustrationRepository;
		}

		public List<IllustrationModel> GetIllustrationsByProductModel(int productModelID) {
			//query from Illustration side
			var illusData = _illustrationRepository
				.Get(x => x.ProductModels)
				.Where(x => x.ProductModels.Select(y => y.ProductModelID == productModelID).FirstOrDefault())
				.ToList();
			var model = Mapper.Map<List<IllustrationModel>>(illusData);
			return model;

			//...from ProductModel side
			//var data = _productModelRepository
			//	.Get(x => x.Illustrations)
			//	.FirstOrDefault(pm => pm.ProductModelID == productModelID);
			//return data.Illustrations.ToList();
		}
	}
}
