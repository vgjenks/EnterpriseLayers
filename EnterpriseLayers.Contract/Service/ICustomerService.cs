using EnterpriseLayers.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Contract.Service {
	public interface ICustomerService {
		List<Customer> GetLastCustomers(int take = 10);
	}
}
