using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseLayers.Model.Domain {
	[Table("Production.Illustration")]
	public class Illustration {
		public Illustration() {
			ProductModels = new List<ProductModel>();
		}

		public int IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }

		//[ForeignKey("IllustrationID")] //many-to-many: Don't need it?
		public ICollection<ProductModel> ProductModels { get; set; }
	}
}
