using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EnterpriseLayers.Model.Domain {
	[Table("Sales.Customer")]
	public class Customer {
		public Customer() {
			SalesOrderHeaders = new List<SalesOrderHeader>();
		}

		public int CustomerID { get; set; }

		public int? PersonID { get; set; }

		public int? StoreID { get; set; }

		public int? TerritoryID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Required]
		[StringLength(10)]
		public string AccountNumber { get; set; }

		public Guid rowguid { get; set; }

		public DateTime ModifiedDate { get; set; }

		public Person Person { get; set; }

		public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
	}
}
