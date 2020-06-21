using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedLogging.BL
{
    public class LogsTableData : ILogsTableData
    {
        private readonly ILogsTable _logsTable;
        public LogsTableData(ILogsTable logsTable)
        {
            _logsTable = logsTable;
        }
        public List<ServiceBasedLogs> GetLogsBasedOnSevice(string serviceName)
        {
            List<ServiceBasedLogs> logList = null;

            logList = _logsTable.GetLogsServiceName(serviceName).Select(x=>new ServiceBasedLogs
            {
                ServiceName = serviceName,
                LogMessages = x.LogMessages,
                DateAndTime = x.DateAndTime,
                Status = x.Status
            }).ToList();

            return logList;
        }

        public List<ServiceBasedLogs> GetAllLogsForAllServices()
        {
            List<ServiceBasedLogs> logList = null;

            logList = _logsTable.GetAllLogs();

            return logList;
        }
    }
}
