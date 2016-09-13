using EnterpriseLayers.Contract.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Data.Access {
	public class AdoUnitOfWork : IUnitOfWork {
		private IDbConnection _connection;
		private bool _ownsConnection;
		private IDbTransaction _transaction;

		public IDbContext Context {
			get {
				throw new NotImplementedException();
			}

			set {
				throw new NotImplementedException();
			}
		}

		public AdoUnitOfWork(IDbConnection connection, bool ownsConnection) {
			_connection = connection;
			_ownsConnection = ownsConnection;
			_transaction = connection.BeginTransaction();
			Trace.Write("Data.Access: ADO UoW created...transaction started");
		}

		public IDbCommand CreateCommand() {
			var command = _connection.CreateCommand();
			command.Transaction = _transaction;
			Trace.Write("Data.Access: Command created");
			return command;
		}

		public void SaveChanges() {
			if (_transaction == null)
				throw new InvalidOperationException("Transaction have already been commited. Check your transaction handling.");

			_transaction.Commit();
			_transaction = null;
			Trace.Write("Data.Access: Transaction Committed");
		}

		public void Dispose() {
			if (_transaction != null) {
				_transaction.Rollback();
				_transaction = null;
				Trace.Write("Data.Access: Transaction rolled back");
			}

			if (_connection != null && _ownsConnection) {
				_connection.Close();
				_connection = null;
				Trace.Write("Data.Access: Connection closed");
			}
		}
	}
}
