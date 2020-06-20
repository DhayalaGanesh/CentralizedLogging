using CentralizedLogging.DB.EF.Models;
using CentralizedLogging.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CentralizedLogging.DB.EF.Data
{
    public class LogsTable : ILogsTable
    {
        public List<Logs> GetLogsServiceName(string serviceName)
        {
            List<Logs> logs = null;
            using (CentralizedLoggingContext dbContext = new CentralizedLoggingContext())
            {
                logs = (from lg in dbContext.Logs
                        where lg.Service.ServiceName == serviceName
                        select lg).ToList();
            }

            return logs;
        }

        public List<ServiceBasedLogs> GetAllLogs()
        {
            List<ServiceBasedLogs> logs = null;
            using (CentralizedLoggingContext dbContext = new CentralizedLoggingContext())
            {
                logs = (from lg in dbContext.Logs
                        select new ServiceBasedLogs
                        {
                            ServiceName = lg.Service.ServiceName,
                            LogMessages = lg.LogMessages,
                            DateAndTime = lg.DateAndTime
                        }).ToList();
            }

            return logs;
        }
    }
}
