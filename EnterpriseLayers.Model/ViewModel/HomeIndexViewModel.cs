using EnterpriseLayers.Model.Domain;
using System.Collections.Generic;

namespace EnterpriseLayers.Model.ViewModel {
	public class HomeIndexViewModel {
		public Customer ValidCustomer { get; set; }
		public List<Customer> LatestCustomers { get; set; }
	}
}
