using EnterpriseLayers.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Contract.Service {
	public interface IContactTypeService {
		List<ContactType> GetAll();
		ContactType Get(int contactTypeID);
		void Save(ContactType contactType);
		void Delete(int contactTypeID);
	}
}
