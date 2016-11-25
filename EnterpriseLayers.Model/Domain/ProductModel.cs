using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Model.Domain {
	[Table("Production.ProductModel")]
	public class ProductModel {
		public ProductModel() {
			Illustrations = new List<Illustration>();
		}

		public int ProductModelID { get; set; }
		public string Name { get; set; }
		public DateTime ModifiedDate { get; set; }

		//[ForeignKey("ProductModelID")] //many-to-many: Don't need it?
		public ICollection<Illustration> Illustrations { get; set; }
	}
}
