using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLLPcpModelApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPcpModelApp.Tests
{
    [TestClass()]
    public class BLLUtilsTests
    {
        [TestMethod()]
        public void CalcEdadTest()
        {
            var result = BLLUtils.CalcEdad(new DateTime(1969, 07, 31));
            Assert.Fail();
        }
    }
}