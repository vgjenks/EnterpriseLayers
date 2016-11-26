using AutoMapper;
using System.Collections.Generic;

namespace EnterpriseLayers.Service {
	public static class AutoMapperExtensions {
		public static T To<T>(this object source) {
			return Mapper.Map<T>(source);
		}

		public static List<T> To<T>(this List<object> source) {
			return Mapper.Map<List<T>>(source);
		}
	}
}
