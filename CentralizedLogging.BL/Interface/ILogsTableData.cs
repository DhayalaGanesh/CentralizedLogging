using CentralizedLogging.ViewModel;
using System.Collections.Generic;

namespace CentralizedLogging.BL
{
    public interface ILogsTableData
    {
        List<ServiceBasedLogs> GetLogsBasedOnSevice(string serviceName);
        List<ServiceBasedLogs> GetLogsBasedOnSevice(List<string> serviceNames);
        List<ServiceBasedLogs> GetAllLogsForAllServices();
        bool AddLogs(ServiceBasedLogs log);
    }
}
