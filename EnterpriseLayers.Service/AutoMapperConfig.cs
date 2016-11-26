using AutoMapper;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.Model;

namespace EnterpriseLayers.Service {
	public class AutoMapperConfig {
		public static void Load() {
			Mapper.Initialize(cfg => {
				cfg.CreateMap<ProductModel, ProductModelModel>()
					//.ForMember(dest => dest.Illustrations, opt => opt.Ignore()) 
					.MaxDepth(2) //NOTE: Had to limit depth - many-to-many causing StackOverflowException!
					.ReverseMap();
				cfg.CreateMap<Illustration, IllustrationModel>()
					//.ForMember(dest => dest.ProductModels, opt => opt.Ignore()) 
					.MaxDepth(2) //NOTE: Had to limit depth - many-to-many causing StackOverflowException!
					.ReverseMap();
			});
		}
	}
}
