using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.DB.EF.Data.Interface;
using CentralizedLoggingSystem.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralizedLogging.Tests
{
    class ServiceControllerTests
    {
        [TestCase]
        public void VerifyNumberOfServices()
        {
            Mock<ILogger<ServicesController>> _logger = new Mock<ILogger<ServicesController>>();
            IServiceListTable serviceListTable = new ServiceListTable();
            ServicesController servicesController = new ServicesController(_logger.Object, serviceListTable);
            var returnedValue = servicesController.GetServicesList();

            Assert.AreEqual(5, returnedValue.Count());
        }
    }
}
