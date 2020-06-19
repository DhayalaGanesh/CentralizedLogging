using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.DB.EF.Data.Interface;
using NUnit.Framework;
using System.Collections.Generic;

namespace CentralizedLogging.Tests
{
    public class ServiceListTableTests
    {
        [TestCase]
        public void VerifyNumberOfServices()
        {
            IServiceListTable serviceListTable = new ServiceListTable();
            List<string> returnedValue = serviceListTable.GetServiceList();
            Assert.AreEqual(5, returnedValue.Count);
        }
    }
}