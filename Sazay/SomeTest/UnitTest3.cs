using Sazay.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SomeTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("AIDS", "Air_is_drug"));
            Assert.IsTrue(page.Auth("tgbon", "pas123"));
            Assert.IsTrue(page.Auth("kiria", "kekria123"));
            
        }
    }
}
