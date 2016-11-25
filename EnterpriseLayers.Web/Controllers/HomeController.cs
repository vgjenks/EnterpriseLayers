using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Data.Access;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Model.ViewModel;
using EnterpriseLayers.Service;
using EnterpriseLayers.Utility.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseLayers.Web.Controllers {
	public class HomeController : Controller {

		//GET: Home/Index
		public ActionResult Index() {
			//EventLog.Log("BEGIN: Request initiated...");
			var model = new HomeIndexViewModel();

			//get UoW instance
			string dbPlatform = ConfigurationManager.AppSettings["databasePlatform"];
			using (var uow = UnitOfWorkFactory.Create(dbPlatform)) {
				//get services
				var customerService = new CustomerService(uow);
				var contactTypeService = new ContactTypeService(uow);

				//pull some random data
				model = customerService.GetHomeIndexViewModel(
					latest: 50,
					validCustomerID: 29825);

				//do some other random stuff w/ data
				List<ContactType> ctList = contactTypeService.GetAll();

				var newContactType = new ContactType {
					Name = "Interplanetary Explorer",
					ModifiedDate = DateTime.Now
				};
				contactTypeService.Save(newContactType);
				uow.SaveChanges(); //commit to get new ID

				ContactType ct = contactTypeService.Get(newContactType.ContactTypeID);
				contactTypeService.Delete(ct.ContactTypeID);

				//commit (or not)
				uow.SaveChanges();
			} //close and dispose

			//EventLog.Log("END: Request completed...");
			return View(model);
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";
			return View();
		}
	}
}