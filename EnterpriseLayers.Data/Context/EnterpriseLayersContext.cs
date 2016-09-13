using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Utility.Logging;

namespace EnterpriseLayers.Data.Context {
	public class EnterpriseLayersContext : DbContext, IDbContext {
		public EnterpriseLayersContext()
			: base("name=EnterpriseLayersData") {
			//EventLog.Log($"DbContext created. Status: {Database.Connection.State}");
		}

		public virtual DbSet<Person> Person { get; set; }
		public virtual DbSet<Customer> Customer { get; set; }
		public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
		public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
		public virtual DbSet<ContactType> ContactType { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<Person>()
				.Property(e => e.PersonType)
				.IsFixedLength();

			modelBuilder.Entity<Person>()
				.HasMany(e => e.Customers)
				.WithOptional(e => e.Person)
				.HasForeignKey(e => e.PersonID);

			modelBuilder.Entity<Customer>()
				.Property(e => e.AccountNumber)
				.IsUnicode(false);

			modelBuilder.Entity<Customer>()
				.HasMany(e => e.SalesOrderHeaders)
				.WithRequired(e => e.Customer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<SalesOrderDetail>()
				.Property(e => e.UnitPrice)
				.HasPrecision(19, 4);

			modelBuilder.Entity<SalesOrderDetail>()
				.Property(e => e.UnitPriceDiscount)
				.HasPrecision(19, 4);

			modelBuilder.Entity<SalesOrderDetail>()
				.Property(e => e.LineTotal)
				.HasPrecision(38, 6);

			modelBuilder.Entity<SalesOrderHeader>()
				.Property(e => e.CreditCardApprovalCode)
				.IsUnicode(false);

			modelBuilder.Entity<SalesOrderHeader>()
				.Property(e => e.SubTotal)
				.HasPrecision(19, 4);

			modelBuilder.Entity<SalesOrderHeader>()
				.Property(e => e.TaxAmt)
				.HasPrecision(19, 4);

			modelBuilder.Entity<SalesOrderHeader>()
				.Property(e => e.Freight)
				.HasPrecision(19, 4);

			modelBuilder.Entity<SalesOrderHeader>()
				.Property(e => e.TotalDue)
				.HasPrecision(19, 4);
		}

		void IDbContext.SaveChanges() {
			SaveChanges();
			//EventLog.Log($"DbContext.SaveChanges() called. Status: {Database.Connection.State}");
		}
	}
}
