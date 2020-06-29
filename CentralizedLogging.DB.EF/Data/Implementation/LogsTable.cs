using CentralizedLogging.DB.EF.Models;
using CentralizedLogging.ViewModel;
using Microsoft.VisualBasic;
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

        public IQueryable<Logs> GetLogsServiceName(List<string> serviceName)
        {
            IQueryable<Logs> logs = null;
            logs = (from lg in _centralizedLoggingContext.Logs
                    where serviceName.Contains(lg.Service.ServiceName)
                    select lg);

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
                        DateAndTime = lg.DateAndTime,
                        Status = lg.Status
                    }).ToList();

            return logs;
        }

        public bool AddLogsToTable(ServiceBasedLogs serviceBasedLogs)
        {
            bool isAdded = false;
            int id = _centralizedLoggingContext.ServicesList.Where(x => x.ServiceName == serviceBasedLogs.ServiceName).Select(x => x.Id).FirstOrDefault();
            if (id > 0)
            {
                _centralizedLoggingContext.Logs.Add(new Logs
                {
                    ServiceId = id,
                    LogMessages = serviceBasedLogs.LogMessages,
                    Status = serviceBasedLogs.Status,
                    DateAndTime = DateAndTime.Now
                });
                isAdded = _centralizedLoggingContext.SaveChanges() > 0;
            }

            return isAdded;
        }


    }
}
