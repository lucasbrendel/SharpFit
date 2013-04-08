using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpFit;

namespace SharpFit.Test
{
    [TestClass]
    public class APIAccessTest
    {
        [TestMethod]
        public void IsValidDateTest()
        {
            bool res = APIAccess.IsValidDate(@"8888-98-09");
        }
    }
}
