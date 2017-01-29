using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Manager_UI;
using Business_Manager_UI.Controllers;

namespace Test_Neas_Project
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainWindow mw = new MainWindow();
            Controller ctrl = new Controller();
            var list = ctrl.GetAllDistricts();
            Assert.AreEqual(list.Count, 9);
        }
    }
}
