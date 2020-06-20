using CentralizedLogging.DB.EF.Models;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedLogging.DB.EF.Data
{
    public class ServiceListTable: IServiceListTable
    {
        public List<string> GetServiceList()
        {
            List<string> serviceList = null;
            using (var centralizedLoggingContext = new CentralizedLoggingContext())
            {
                serviceList = (from sl in centralizedLoggingContext.ServicesList select sl.ServiceName).ToList();
            }
            return serviceList;
        }
    }
}
