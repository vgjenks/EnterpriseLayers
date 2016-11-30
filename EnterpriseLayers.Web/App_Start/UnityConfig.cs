using System;
using Microsoft.Practices.Unity;
using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Repository;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Service;
using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Data.Access;
using System.Configuration;
using Microsoft.Practices.Unity.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace EnterpriseLayers.Web.App_Start {
	/// <summary>
	/// Specifies the Unity configuration for the main container.
	/// </summary>
	public class UnityConfig {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container) {
			// NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
			// container.LoadConfiguration();

			//***IMPORTANT! required by PerRequestLifetimeManager to properly dispose of context at end of request
			DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));

			//Unit of Work per-request in MVC
			container.RegisterType<IUnitOfWork>(
				new PerRequestLifetimeManager(),
				new InjectionFactory(c => {
					string dbPlatform = ConfigurationManager.AppSettings["databasePlatform"];
					var uow = new UnitOfWorkFactory(dbPlatform);
					return uow.UnitOfWork;
				})
			);

			//repositories
			container.RegisterType<IRepository<ProductModel>, GenericRepository<ProductModel>>();
			container.RegisterType<IRepository<Illustration>, GenericRepository<Illustration>>();

			//services
			container.RegisterType<IProductModelService, ProductModelService>();
		}
	}
}
