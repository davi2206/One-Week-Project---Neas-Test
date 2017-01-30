using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Manager_UI;
using Business_Manager_UI.Controllers;
using Business_Manager_UI.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Neas_Project
{
    [TestClass]
    public class UnitTest1
    {
        Controller ctrl = new Controller();

        [TestMethod]
        public void TestMethod1()
        {
            List<District> list = ctrl.GetAllDistricts();
            Assert.AreEqual(list.Count, 9);
        }
    }
}
