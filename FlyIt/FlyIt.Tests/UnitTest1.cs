using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FlyIt;
using System.Threading.Tasks;

namespace FlyIt.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<SessionInfo> sessions = null;

            Task.Run(async () =>
            {
                sessions = await InfiniteFlightAccess.GetSessionInfo();
            });
        }
    }
}
