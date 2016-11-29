using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Utility.Logging {
	public class SqlInterceptor : DbCommandInterceptor {
		private readonly string _logFile;
		private readonly int _executionMillisecondThreshold;

		public SqlInterceptor(string logFile, int executionMillisecondThreshold) {
			_logFile = logFile;
			_executionMillisecondThreshold = executionMillisecondThreshold;
		}

		//public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
		//	Executing(interceptionContext);
		//	base.ReaderExecuting(command, interceptionContext);
		//}

		//public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) {
		//	Executed(command, interceptionContext);
		//	base.ReaderExecuted(command, interceptionContext);
		//}

		//public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
		//	Executing(interceptionContext);
		//	base.NonQueryExecuting(command, interceptionContext);
		//}

		//public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
		//	Executed(command, interceptionContext);
		//	base.NonQueryExecuted(command, interceptionContext);
		//}

		//public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
		//	Executing(interceptionContext);
		//	base.ScalarExecuting(command, interceptionContext);
		//}

		//public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
		//	Executed(command, interceptionContext);
		//	base.ScalarExecuted(command, interceptionContext);
		//}

		//private void Executing<T>(DbCommandInterceptionContext<T> interceptionContext) {
		//	var timer = new Stopwatch();
		//	interceptionContext.UserState = timer;
		//	timer.Start();
		//}

		//private void Executed<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext) {
		//	var timer = (Stopwatch)interceptionContext.UserState;
		//	timer.Stop();

		//	if (interceptionContext.Exception != null) {
		//		File.AppendAllLines(
		//			_logFile,
		//			new string[]
		//			{
		//		"FAILED COMMAND",
		//		interceptionContext.Exception.Message,
		//		command.CommandText,
		//		Environment.StackTrace,
		//		string.Empty,
		//		string.Empty,
		//			});
		//	} else if (timer.ElapsedMilliseconds >= _executionMillisecondThreshold) {
		//		File.AppendAllLines(
		//			_logFile,
		//			new string[]
		//			{
		//		$"SLOW COMMAND ({timer.ElapsedMilliseconds}ms)",
		//		command.CommandText,
		//		Environment.StackTrace,
		//		string.Empty,
		//		string.Empty,
		//			});
		//	}
		//}
	}
}
