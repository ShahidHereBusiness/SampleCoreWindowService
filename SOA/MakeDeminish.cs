using System.Diagnostics;
using System.Linq.Expressions;

namespace SOA
{
    public static class MakeDeminish
    {
        public static string Source { get; set; } = "TimerWorkerMinimalApi";
        public static string LogName { get; set; } = "WorkerApp";
        public static Double CountDown { get; set; } = 60000D;
        public static bool LogEvent(string str)
        {
            try
            {
                if (!SOAV.Validation.ErrorFormat(str))
                {
                    // Run your graceful clean-up actions
                    if (!EventLog.SourceExists(Source))
                    {
                        EventLog.CreateEventSource(Source, LogName);
                    }
                    EventLog.WriteEntry(Source, str, EventLogEntryType.Information);
                    return true;
                }
            }
            catch(Exception ex)
            {
                SOAV.FileAppLog.FSLog("\\DevLogs", "CoreBackgroundService:LogEvent:Exception", $"Input:{str},Exception:{ex}");
            }
            finally
            {
                //Diminish Here
                SOAV.FileAppLog.FSLog("\\DevLogs", "CoreBackgroundService:LogEvent", $"Input:{str}");
            }
            return false;
        }
    }
}