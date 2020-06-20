using System.Collections.Generic;

namespace CentralizedLogging.DB.EF.Data
{
    public interface IServiceListTable
    {
        List<string> GetServiceList();
    }
}
