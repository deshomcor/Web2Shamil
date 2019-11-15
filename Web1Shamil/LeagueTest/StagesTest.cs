using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class StagesTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenStagesName()
        {
            Stage stage = new Stage();
            String result = stage.StageName;
            Assert.AreEqual("Play-Off", result);
        }
    }
}
