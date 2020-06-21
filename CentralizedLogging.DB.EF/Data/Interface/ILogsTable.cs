using CentralizedLogging.DB.EF.Models;
using CentralizedLogging.ViewModel;
using System.Collections.Generic;

namespace CentralizedLogging.DB.EF.Data
{
    public interface ILogsTable
    {
        List<Logs> GetLogsServiceName(string serviceName);
        List<ServiceBasedLogs> GetAllLogs();
    }
}
