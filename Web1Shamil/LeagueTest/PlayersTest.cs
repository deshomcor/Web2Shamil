using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class PlayersTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenPlayersName()
        {
            Players player = new Players();
            String result = player.PlayersName + " " + player.PlayersSurname;
            Assert.AreEqual("Shamil Aripov", result);
        }
    }
}
