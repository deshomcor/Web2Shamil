using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Web1Shamil.Models.Classes;

namespace LeagueTest
{
    [TestClass]
    public class UniformsTest
    {
        [TestMethod]
        public void checkNameOfNonWrittenUniformsColor()
        {
            Uniforms uniforms = new Uniforms();
            String result = uniforms.UniformsColor;
            Assert.AreEqual("White", result);
        }
    }
}
