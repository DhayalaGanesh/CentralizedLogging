using CentralizedLogging.DB.EF.Models;
using CentralizedLogging.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedLogging.DB.EF.Data
{
    public interface ILogsTable
    {
        List<Logs> GetLogsServiceName(string serviceName);
        List<ServiceBasedLogs> GetAllLogs();
        IQueryable<Logs> GetLogsServiceName(List<string> serviceName);
        bool AddLogsToTable(ServiceBasedLogs serviceBasedLogs);
    }
}
