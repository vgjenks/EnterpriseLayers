using System;
using System.Collections.Generic;

namespace EnterpriseLayers.Model.Model {
	public class IllustrationModel {
		public int IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ICollection<ProductModelModel> ProductModels { get; set; }

		public IllustrationModel() {
			ProductModels = new List<ProductModelModel>();
		}
	}
}
