using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class PositionsTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenPositionsName()
        {
            Positions position = new Positions();
            String result = position.PositionsName;
            Assert.AreEqual("Goalkeeper", result);
        }
    }
}
