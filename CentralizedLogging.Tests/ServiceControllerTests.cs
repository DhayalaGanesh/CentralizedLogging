using CentralizedLogging.BL;
using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.DB.EF.Models;
using CentralizedLoggingSystem.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace CentralizedLogging.Tests
{
    class ServiceControllerTests
    {
        [TestCase]
        public void VerifyNumberOfServices()
        {
            Mock<ILogger<ServicesController>> _logger = new Mock<ILogger<ServicesController>>();
            Mock<CentralizedLoggingContext> centralizedLoggingContext = new Mock<CentralizedLoggingContext>();
            IServiceListTable serviceListTable = new ServiceListTable(centralizedLoggingContext.Object);
            Mock<ILogsTableData> _logsTableData = new Mock<ILogsTableData>();
            ServicesController servicesController = new ServicesController(_logger.Object, serviceListTable, _logsTableData.Object);
            var returnedValue = servicesController.GetServicesList();

            Assert.AreEqual(5, returnedValue.Count());
        }
    }
}
