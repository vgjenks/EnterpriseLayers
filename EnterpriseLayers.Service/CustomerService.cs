using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Data.Context;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.ViewModel;
using EnterpriseLayers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Service {
	public class CustomerService : UnitOfWorkService, ICustomerService {
		private IRepository<Customer> _customerRepo;
		private IRepository<SalesOrderHeader> _salesOrderRepo;

		public CustomerService(IUnitOfWork uow) : base(uow) {
			_customerRepo = new GenericRepository<Customer>(uow);
			_salesOrderRepo = new GenericRepository<SalesOrderHeader>(uow);
		}

		public List<Customer> GetLastCustomers(int take = 10) {
			return _customerRepo
				.Get(c => c.Person)
				.OrderByDescending(c => c.CustomerID)
				.Take(take)
				.ToList();
		}

		public Customer GetValidCustomer(int customerID) {
			Customer customer = null;
			if (_salesOrderRepo.All.Count(x => x.CustomerID == customerID) > 0) {
				customer = _customerRepo.Find(customerID);
			}
			return customer;
		}

		public HomeIndexViewModel GetHomeIndexViewModel(int latest, int validCustomerID) {
			var model = new HomeIndexViewModel {
				ValidCustomer = GetValidCustomer(validCustomerID),
				LatestCustomers = GetLastCustomers(latest)
			};
			return model;
		}
	}
}
