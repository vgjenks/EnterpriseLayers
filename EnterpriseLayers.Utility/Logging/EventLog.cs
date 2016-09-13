using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
