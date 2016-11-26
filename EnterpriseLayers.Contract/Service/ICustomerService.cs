using EnterpriseLayers.Model.Domain;
using System.Collections.Generic;

namespace EnterpriseLayers.Contract.Service {
	public interface ICustomerService {
		List<Customer> GetLastCustomers(int take = 10);
	}
}
