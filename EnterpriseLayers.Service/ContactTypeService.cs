using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Service {
	public class ContactTypeService : IContactTypeService {
		private IRepository<ContactType> _contactTypeRepository;

		public ContactTypeService(IUnitOfWork unitOfWork) {
			if (unitOfWork == null)
				throw new ArgumentNullException("Missing Unit of Work Implementation");

			_contactTypeRepository = new GenericRepository<ContactType>(unitOfWork);
		}

		public List<ContactType> GetAll() {
			return _contactTypeRepository
				.All
				.OrderBy(ct => ct.Name)
				.ToList();
		}

		public ContactType Get(int contactTypeID) {
			return _contactTypeRepository.Find(contactTypeID);
		}

		public void Save(ContactType contactType) {
			if (contactType.ContactTypeID == 0)
				_contactTypeRepository.Insert(contactType);
			else
				_contactTypeRepository.Update(contactType);
		}

		public void Delete(int contactTypeID) {
			_contactTypeRepository.Delete(contactTypeID);
		}
	}
}
