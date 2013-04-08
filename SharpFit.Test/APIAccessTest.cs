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
            Assert.IsTrue(APIAccess.IsValidDate(@"8888-98-09"));

            Assert.IsFalse(APIAccess.IsValidDate(@"94-00-93"));

            Assert.IsFalse(APIAccess.IsValidDate(@"4f04-54-32"));
        }
    }
}
