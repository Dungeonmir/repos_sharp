using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib.Tests
{
    [TestClass()]
    public class CalcTests
    {
        public TestContext TestContext { get; set; }
        public Calc calc = new Calc();
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "Material", DataAccessMethod.Sequential)]
        
        [TestMethod]
        public void Material_Calc_From_XML()
        {
            int product_type = Convert.ToInt32(TestContext.DataRow["product_type"]);
            int material_type = Convert.ToInt32(TestContext.DataRow["material_type"]);
            double count = Convert.ToDouble(TestContext.DataRow["count"]);
            double length = Convert.ToDouble(TestContext.DataRow["length"]);
            double width = Convert.ToDouble(TestContext.DataRow["width"]);

            int expected = Convert.ToInt32(TestContext.DataRow["expected"]);
            int result = calc.calculate(product_type, material_type, count, length, width);
            Assert.AreEqual(expected, result);
        }
        
    }
}