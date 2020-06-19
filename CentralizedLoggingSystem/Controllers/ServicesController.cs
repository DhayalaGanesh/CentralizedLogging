using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizedLogging.DB.EF.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CentralizedLoggingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ServicesController> _logger;
        private readonly IServiceListTable _serviceListTable;

        public ServicesController(ILogger<ServicesController> logger,
            IServiceListTable serviceListTable)
        {
            _logger = logger;
            _serviceListTable = serviceListTable;
        }

        [HttpGet]
        public IEnumerable<string> GetServicesList()
        {
            return _serviceListTable.GetServiceList();
        }
    }
}
