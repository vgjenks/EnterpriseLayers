using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Exception {
	public class DataException : System.Exception {
		public DataException() {
		}

		public DataException(DbEntityValidationException ex) {
			var errorMessages = ex.EntityValidationErrors
					.SelectMany(x => x.ValidationErrors)
					.Select(x => x.ErrorMessage);
			var fullErrorMessage = string.Join("; ", errorMessages);
			string allEntityExceptions = string.Concat(
				ex.Message,
				" The validation errors are: ",
				fullErrorMessage);
			this.Source = allEntityExceptions;
		}
	}
}
