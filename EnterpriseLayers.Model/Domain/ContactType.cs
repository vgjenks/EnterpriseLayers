using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Model.Domain {
	[Table("Person.ContactType")]
	public class ContactType {
		public ContactType() {

		}

		[Key]
		public int ContactTypeID { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		public DateTime ModifiedDate { get; set; }
	}
}
