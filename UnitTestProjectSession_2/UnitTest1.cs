using Microsoft.VisualStudio.TestTools.UnitTesting;
using Session_2_wpf_demoExam.db;
using Session_2_wpf_demoExam.pages;
using System;

namespace UnitTestProjectSession_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            materials2Entities m = new materials2Entities();
            Assert.IsNotNull(MaterialsPage.getMaterials(m));
        }
    }
}
