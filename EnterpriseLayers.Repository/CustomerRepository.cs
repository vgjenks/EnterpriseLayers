using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseLayers.Data.Context;
using EnterpriseLayers.Contract.DataAccess;

namespace EnterpriseLayers.Repository {
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository {
		//public CustomerRepository(EnterpriseLayersContext dbContext) : base(dbContext) {
		public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {
		}
	}
}
