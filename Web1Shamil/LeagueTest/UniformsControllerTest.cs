﻿using System;
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
    public class UniformsControllerTest
    {
        [TestMethod]
        public void CreateMethodTest()
        {
            var options = new DbContextOptionsBuilder<MContext>()
                .UseInMemoryDatabase(databaseName: "DB")
                .Options;
            var controller = new UniformsController(new MContext(options));
            using (var context = new MContext(options))
            {
                context.Uniforms.Add(new Uniforms());
                context.SaveChanges();
            }

            using (var context = new MContext(options))
            {
                var result = controller.Create(new Uniforms());
                Assert.AreEqual(true, result.IsCompletedSuccessfully);
            }
        }
    }
}