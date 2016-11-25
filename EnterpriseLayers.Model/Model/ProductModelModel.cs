using System;
using System.Collections.Generic;

namespace EnterpriseLayers.Model.Model {
	public class ProductModelModel {
		public int ProductModelID { get; set; }
		public string Name { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ICollection<IllustrationModel> Illustrations { get; set; }

		public ProductModelModel() {
			Illustrations = new List<IllustrationModel>();
		}
	}
}
