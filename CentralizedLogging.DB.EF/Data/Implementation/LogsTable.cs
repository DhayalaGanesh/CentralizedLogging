using CentralizedLogging.DB.EF.Models;
using CentralizedLogging.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedLogging.DB.EF.Data
{
    public class LogsTable : ILogsTable
    {
        private readonly CentralizedLoggingContext _centralizedLoggingContext;
        public LogsTable(CentralizedLoggingContext centralizedLoggingContext)
        {
            _centralizedLoggingContext = centralizedLoggingContext;
        }
        public List<Logs> GetLogsServiceName(string serviceName)
        {
            List<Logs> logs = null;
            logs = (from lg in _centralizedLoggingContext.Logs
                    where lg.Service.ServiceName == serviceName
                    select lg).ToList();

            return logs;
        }

        public List<ServiceBasedLogs> GetAllLogs()
        {
            List<ServiceBasedLogs> logs = null;
            logs = (from lg in _centralizedLoggingContext.Logs
                    select new ServiceBasedLogs
                    {
                        ServiceName = lg.Service.ServiceName,
                        LogMessages = lg.LogMessages,
                        DateAndTime = lg.DateAndTime
                    }).ToList();

            return logs;
        }
    }
}
