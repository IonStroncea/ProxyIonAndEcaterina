using Common;
using DataBaseWriter.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProxyTest
{
    [TestClass]
    public class DataBaseWritterTest
    {
        [TestMethod]
        public void WriteDB_DBRequest_1()
        {
            //Arrage
            DBRequest request = new DBRequest();
            DataBaseController controller = new DataBaseController(new TestBDWriter());
            int expected = 1;

            //Act
            int result = controller.WriteDB(request);


            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}
