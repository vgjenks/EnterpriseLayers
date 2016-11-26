using System;
using System.Data;

namespace EnterpriseLayers.Data.Access {
	public static class CommandExtensions {
		public static IDataParameter AddParameter(this IDbCommand command, string name, object value) {
			if (command == null) throw new ArgumentNullException("IDbCommand cannot be null");
			if (name == null) throw new ArgumentNullException("Parameter name is required");

			var p = command.CreateParameter();
			p.ParameterName = name;
			p.Value = value ?? DBNull.Value;
			command.Parameters.Add(p);
			return p;
		}

		public static IDataParameter AddOutputParameter(this IDbCommand command, string name) {
			if (command == null) throw new ArgumentNullException("IDbCommand cannot be null");
			if (name == null) throw new ArgumentNullException("Parameter name is required");

			var p = command.CreateParameter();
			p.ParameterName = name;
			p.Direction = ParameterDirection.Output;
			command.Parameters.Add(p);
			return p;
		}

		public static IDataParameter AddInputOutputParameter(this IDbCommand command, string name, object value) {
			if (command == null) throw new ArgumentNullException("IDbCommand cannot be null");
			if (name == null) throw new ArgumentNullException("Parameter name is required");

			var p = command.CreateParameter();
			p.ParameterName = name;
			p.Direction = ParameterDirection.InputOutput;
			p.Value = value ?? DBNull.Value;
			command.Parameters.Add(p);
			return p;
		}
	}
}
