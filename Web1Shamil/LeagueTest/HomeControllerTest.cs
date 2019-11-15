using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web1Shamil.Controllers;

namespace LeagueTest
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void IsNotNull()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}