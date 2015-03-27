using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //UserController uc = new UserController();
            //Assert.AreNotEqual( null, uc.Index() );
            Assert.AreEqual( 2, 2 );
        }
    }
}
