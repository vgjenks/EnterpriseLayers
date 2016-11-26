using EnterpriseLayers.Model.Domain;
using System.Collections.Generic;

namespace EnterpriseLayers.Contract.Service {
	public interface IContactTypeService {
		List<ContactType> GetAll();
		ContactType Get(int contactTypeID);
		void Save(ContactType contactType);
		void Delete(int contactTypeID);
	}
}
