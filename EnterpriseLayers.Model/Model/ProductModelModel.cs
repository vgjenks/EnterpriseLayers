using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Model.Model {
	public class ProductModelModel {
		public int ProductModelID { get; set; }
		public string Name { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ICollection<IllustrationModel> Illustrations { get; set; }
	}
}
