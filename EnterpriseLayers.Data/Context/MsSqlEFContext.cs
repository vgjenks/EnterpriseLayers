using System.Data.Entity;
using EnterpriseLayers.Model.Domain;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
/**
 * The using statement above solves this frustrating NuGet bug: 
 * http://stackoverflow.com/questions/14033193/entity-framework-provider-type-could-not-be-loaded
 **/

namespace EnterpriseLayers.Data.Context {
	public class MsSqlEFContext : DbContext {
		public MsSqlEFContext() : base("name=EnterpriseLayersData") {
			this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s); //print EF sql output
			//EventLog.Log($"DbContext created. Status: {Database.Connection.State}");
		}

		public virtual DbSet<Person> Person { get; set; }
		public virtual DbSet<Customer> Customer { get; set; }
		public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
		public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
		public virtual DbSet<ContactType> ContactType { get; set; }
		public virtual DbSet<ProductModel> ProductModels { get; set; }
		public virtual DbSet<Illustration> Illustration { get; set; }
		public virtual DbSet<ProductModelIllustration> ProductModelIllustrations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			//modelBuilder.HasDefaultSchema("Production"); //global

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

			modelBuilder.Entity<ProductModel>()
						.HasMany(pm => pm.Illustrations)
						.WithMany(i => i.ProductModels)
						.Map(cs => {
							cs.MapLeftKey("ProductModelID");
							cs.MapRightKey("IllustrationID");
							cs.ToTable("ProductModelIllustration", "Production");
						});
		}
	}
}
