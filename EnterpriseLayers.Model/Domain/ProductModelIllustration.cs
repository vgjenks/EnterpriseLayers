using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Model.Domain {
	//[Table("ProductModelIllustration")] //this threw an exception since it's already mapped in Fluent
	public class ProductModelIllustration {
		[Key]
		[Column(Order = 0)]
		//[ForeignKey("ProductModel")]
		public int ProductModelID { get; set; }

		[Key]
		[Column(Order = 1)]
		//[ForeignKey("Illustration")]
		public int IllustrationID { get; set; }

		public ProductModel ProductModel { get; set; }
		public Illustration Illustration { get; set; }
	}
}
