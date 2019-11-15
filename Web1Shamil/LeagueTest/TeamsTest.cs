using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class TeamsTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenTeamsName()
        {
            Teams team = new Teams();
            String result = team.TeamsName;
            Assert.AreEqual("Kairat", result);
        }
    }
}
