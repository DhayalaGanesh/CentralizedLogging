using System;
using System.Collections.Generic;
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
            List<string> services = null;
            try
            {
                services = _serviceListTable.GetServiceList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception is thrown : {ex.Message}");
            }
            return services;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ServiceBasedLogs> GetServicesLogs(string serviceName)
        {
            List<ServiceBasedLogs> serviceBasedLogs = null;
            try
            {
                serviceBasedLogs = _logsTableData.GetLogsBasedOnSevice(serviceName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception is thrown : {ex.Message}");
            }

            return serviceBasedLogs;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ServiceBasedLogs> GetAllLogs()
        {
            List<ServiceBasedLogs> serviceBasedLogs = null;
            try
            {
                serviceBasedLogs = _logsTableData.GetAllLogsForAllServices();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception is thrown : {ex.Message} Stacktrace : {ex.StackTrace}");
            }
            return serviceBasedLogs;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ServiceBasedLogs> GetLogsForServicesList([FromQuery(Name = "serviceNames")] List<string> serviceNames)
        {
            List<ServiceBasedLogs> serviceBasedLogs = null;
            try
            {
                serviceBasedLogs = _logsTableData.GetLogsBasedOnSevice(serviceNames);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception is thrown : {ex.Message} Stacktrace : {ex.StackTrace}");
            }
            return serviceBasedLogs;
        }

        [HttpPost]
        [Route("[action]")]
        public ContentResult AddLogs(ServiceBasedLogs log)
        {
            bool returnedValue = _logsTableData.AddLogs(log);
            ContentResult contentResult = new ContentResult
            {
                StatusCode = returnedValue ? 200 : 500
            };

            return contentResult;
        }
    }
}
