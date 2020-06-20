using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.DB.EF.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedLogging.Tests
{
    public class ServiceListTableTests
    {
        [TestCase]
        public void VerifyNumberOfServices()
        {
            Mock<CentralizedLoggingContext> centralizedLoggingContext = new Mock<CentralizedLoggingContext>();
            IServiceListTable serviceListTable = new ServiceListTable(centralizedLoggingContext.Object);
            List<string> returnedValue = serviceListTable.GetServiceList().ToList();
            Assert.AreEqual(5, returnedValue.Count);
        }
    }
}