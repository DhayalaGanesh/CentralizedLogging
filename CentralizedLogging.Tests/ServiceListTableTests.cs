using CentralizedLogging.DB.EF.Data;
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
            IServiceListTable serviceListTable = new ServiceListTable();
            List<string> returnedValue = serviceListTable.GetServiceList().ToList();
            Assert.AreEqual(5, returnedValue.Count);
        }
    }
}