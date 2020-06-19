using System.Collections.Generic;

namespace CentralizedLogging.DB.EF.Data.Interface
{
    public interface IServiceListTable
    {
        List<string> GetServiceList();
    }
}
