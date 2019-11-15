using System;
using System.Threading.Tasks;
using Web1Shamil.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web1Shamil.Data;
using Web1Shamil.Models.Classes;
using Web1Shamil.Controllers;

namespace Tests
{
    [TestClass]
    public class CoachesControllerTest
    {
        [TestMethod]
        public void CreateMethodTest()
        {
            var options = new DbContextOptionsBuilder<MContext>()
                .UseInMemoryDatabase(databaseName: "DB")
                .Options;
            var controller = new CoachesController(new MContext(options));
            using (var context = new MContext(options))
            {
                context.Coaches.Add(new Coach());
                context.SaveChanges();
            }

            using (var context = new MContext(options))
            {
                var result = controller.Create(new Coach());
                Assert.AreEqual(true, result.IsCompletedSuccessfully);
            }
        }
    }
}