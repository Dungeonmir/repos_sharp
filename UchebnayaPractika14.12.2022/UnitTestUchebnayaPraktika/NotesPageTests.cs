using Microsoft.VisualStudio.TestTools.UnitTesting;
using UchebnayaPractika.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UchebnayaPractika.db;
using System.Windows.Media;
using System.Drawing;
using Color = System.Windows.Media.Color;

namespace UchebnayaPractika.Pages.Tests
{
    [TestClass()]
    public class NotesPageTests
    {
        [TestMethod()]
        public void MakeSolidBrushFromArgbValueTest_IsWorking_True()
        {
            int ARGBcolor = -1;
            SolidColorBrush solidBrush;
            bool result = UchebnayaPractika.Pages.NotesPage.MakeSolidBrushFromArgbValue(ARGBcolor, out solidBrush);
            bool expected = true;
            
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void MakeSolidBrushFromArgbValueTest_Minus1__255_255_255_2555555()
        {
            int ARGBcolor = -1;
            SolidColorBrush solidBrush;
            bool result = UchebnayaPractika.Pages.NotesPage.MakeSolidBrushFromArgbValue(ARGBcolor, out solidBrush);
            var clr = solidBrush.Color;

            Assert.IsTrue(clr.A == 255);
            Assert.IsTrue(clr.R == 255);
            Assert.IsTrue(clr.G == 255);
            Assert.IsTrue(clr.B == 255);
        }
        [TestMethod()]
        public void MakeSolidBrushFromArgbValueTest_5555__0_21_179_0()
        {
            int ARGBcolor = 5555;
            SolidColorBrush solidBrush;
            bool result = UchebnayaPractika.Pages.NotesPage.MakeSolidBrushFromArgbValue(ARGBcolor, out solidBrush);
            var clr = solidBrush.Color;

            Assert.IsTrue(clr.A == 0);
            Assert.IsTrue(clr.R == 0);
            Assert.IsTrue(clr.G == 21);
            Assert.IsTrue(clr.B == 179);
        }
        [TestMethod()]
        public void MakeSolidBrushFromArgbValueTest_16711680__0_255_0_0()
        {
            int ARGBcolor = 16711680;
            SolidColorBrush solidBrush;
            bool result = UchebnayaPractika.Pages.NotesPage.MakeSolidBrushFromArgbValue(ARGBcolor, out solidBrush);
            var clr = solidBrush.Color;

            Assert.IsTrue(clr.A == 0);
            Assert.IsTrue(clr.R == 255);
            Assert.IsTrue(clr.G == 0);
            Assert.IsTrue(clr.B == 0);
        }
    }
}