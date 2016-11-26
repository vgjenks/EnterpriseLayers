using System.Diagnostics;

namespace EnterpriseLayers.Utility.Logging {
	public class EventLog {
		public static void Log(string message) {
			if (message != null) {
				Trace.TraceInformation(message);
				Trace.Flush();
			}
		}
	}
}
