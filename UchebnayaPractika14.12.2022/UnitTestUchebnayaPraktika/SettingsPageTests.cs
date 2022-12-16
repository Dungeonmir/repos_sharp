using Microsoft.VisualStudio.TestTools.UnitTesting;
using UchebnayaPractika.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace UchebnayaPractika.Pages.Tests
{
    [TestClass()]
    public class SettingsPageTests
    {
        [TestMethod()]
        public void ColorToRGB_IsWorking_True()
        {
            Color color = Color.White;
            string rgb;
            bool result = Pages.SettingsPage.ColorToRGB(color,out rgb);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void ColorToRGB_WhiteValue_255_255_255()
        {
            Color color = Color.White;
            string rgb;
            Pages.SettingsPage.ColorToRGB(color, out rgb);
            string result = rgb;
            string expected = "255 255 255";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ColorToRGB_LightSkyBlue_135_206_250()
        {
            Color color = Color.LightSkyBlue;
            string rgb;
            Pages.SettingsPage.ColorToRGB(color, out rgb);
            string result = rgb;
            string expected = "135 206 250";
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void ColorToRGB_DarkRed_139_0_0()
        {
            Color color = Color.DarkRed;
            string rgb;
            Pages.SettingsPage.ColorToRGB(color, out rgb);
            string result = rgb;
            string expected = "139 0 0";
            Assert.AreEqual(expected, result);
        }
    }
}