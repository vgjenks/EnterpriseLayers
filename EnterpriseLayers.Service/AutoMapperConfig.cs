using AutoMapper;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Service {
	public class AutoMapperConfig {
		public static void Load() {
			Mapper.Initialize(m => {
				m.CreateMap<ProductModel, ProductModelModel>().ReverseMap();
				m.CreateMap<Illustration, IllustrationModel>().ReverseMap();
			});
		}
	}
}
