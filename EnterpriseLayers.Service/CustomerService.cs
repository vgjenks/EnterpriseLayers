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
	public class CustomerService : ICustomerService {
		private IRepository<Customer> _customerRepository;
		private IRepository<SalesOrderHeader> _salesOrderRepository;

		public CustomerService(IUnitOfWork unitOfWork) {
			if (unitOfWork == null)
				throw new ArgumentNullException("Missing Unit of Work Implementation");

			_customerRepository = new GenericRepository<Customer>(unitOfWork);
			_salesOrderRepository = new GenericRepository<SalesOrderHeader>(unitOfWork);
		}

		public List<Customer> GetLastCustomers(int take = 10) {
			return _customerRepository
				.Get(c => c.Person)
				.OrderByDescending(c => c.CustomerID)
				.Take(take)
				.ToList();
		}

		public Customer GetValidCustomer(int customerID) {
			Customer customer = null;
			if (_salesOrderRepository.All.Count(x => x.CustomerID == customerID) > 0) {
				customer = _customerRepository.Find(customerID);
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
