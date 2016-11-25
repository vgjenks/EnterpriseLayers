using EnterpriseLayers.Model.Model;
using System.Collections.Generic;

namespace EnterpriseLayers.Contract.Service {
	public interface IProductModelService {
		List<IllustrationModel> GetIllustrationsByProductModel(int productModelID);
	}
}
