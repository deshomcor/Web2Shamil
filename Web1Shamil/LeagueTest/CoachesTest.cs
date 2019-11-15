using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class CoachesTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenCoachesName()
        {
            Coach coach = new Coach();
            String result = coach.CoachName;
            Assert.AreEqual("Vasya", result);
        }
    }
}
