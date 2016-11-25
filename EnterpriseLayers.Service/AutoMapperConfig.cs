using AutoMapper;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.Model;

namespace EnterpriseLayers.Service {
	public class AutoMapperConfig {
		public static void Load() {
			Mapper.Initialize(cfg => {
				cfg.CreateMap<ProductModel, ProductModelModel>()
					//.ForMember(pm => pm.Illustrations, model => model.MapFrom(m => m.Illustrations))
					//.ForMember(dest => dest.Illustrations, opt => opt.Ignore()) 
					.MaxDepth(2) //NOTE: Had to limit depth - many-to-many causing StackOverflowException!
					.ReverseMap();
				cfg.CreateMap<Illustration, IllustrationModel>()
					//.ForMember(pm => pm.ProductModels, model => model.MapFrom(m => m.ProductModels))
					//.ForMember(dest => dest.ProductModels, opt => opt.Ignore()) 
					.MaxDepth(2) //NOTE: Had to limit depth - many-to-many causing StackOverflowException!
					.ReverseMap();
			});
		}
	}
}
