using EnterpriseLayers.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Contract.DataAccess {
	public interface IDbContext {
		DbSet<Person> Person { get; set; }
		DbSet<Customer> Customer { get; set; }
		DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
		DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
		void SaveChanges();
		void Dispose();
	}
}
