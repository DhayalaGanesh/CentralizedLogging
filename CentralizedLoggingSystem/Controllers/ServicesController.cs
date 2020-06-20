using System.Collections.Generic;
using System.Linq;
using CentralizedLogging.BL;
using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CentralizedLoggingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IServiceListTable _serviceListTable;
        private readonly ILogsTableData _logsTableData;

        public ServicesController(ILogger<ServicesController> logger,
            IServiceListTable serviceListTable,
            ILogsTableData logsTableData)
        {
            _logger = logger;
            _serviceListTable = serviceListTable;
            _logsTableData = logsTableData;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<string> GetServicesList()
        {
            return _serviceListTable.GetServiceList();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ServiceBasedLogs> GetServicesLogs(string serviceName)
        {
            return _logsTableData.GetLogsBasedOnSevice(serviceName);
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ServiceBasedLogs> GetAllLogs()
        {
            return _logsTableData.GetAllLogsForAllServices();
        }
    }
}
