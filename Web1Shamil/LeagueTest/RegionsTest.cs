using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class RegionsTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenRegionsName()
        {
            Regions regions = new Regions();
            String result = regions.RegionsName;
            Assert.AreEqual("Asia", result);
        }
    }
}
