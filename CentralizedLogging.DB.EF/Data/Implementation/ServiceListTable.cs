using CentralizedLogging.DB.EF.Models;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedLogging.DB.EF.Data
{
    public class ServiceListTable: IServiceListTable
    {
        private readonly CentralizedLoggingContext _centralizedLoggingContext;
        public ServiceListTable(CentralizedLoggingContext centralizedLoggingContext)
        {
            _centralizedLoggingContext = centralizedLoggingContext;
        }

        public List<string> GetServiceList()
        {
            List<string> serviceList = null;
            serviceList = (from sl in _centralizedLoggingContext.ServicesList select sl.ServiceName).ToList();
            return serviceList;
        }
    }
}
