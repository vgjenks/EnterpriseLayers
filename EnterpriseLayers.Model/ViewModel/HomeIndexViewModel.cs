using EnterpriseLayers.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Model.ViewModel {
	public class HomeIndexViewModel {
		public Customer ValidCustomer { get; set; }
		public List<Customer> LatestCustomers { get; set; }
	}
}
