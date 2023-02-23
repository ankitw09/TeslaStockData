
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using TeslaStockData.Models;
using TeslaStockData.Repository;

namespace TeslaUnitTest
{
    [TestClass]

    public class UnitTest1
    {
        [TestMethod]
        public void GetStockData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["demo"].ToString();
            var mockDatabase = new Mock<ITeslaRepo>();
            var Repo = new TeslaRepo(connectionString);
            int expectedResult = 13;

            var result = Repo.GetStockData(1);

            Assert.AreEqual(expectedResult, result.Count);

        }
        [TestMethod]
        public void AddStockData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["demo"].ToString();
            var mockDatabase = new Mock<ITeslaRepo>();
            var Repo = new TeslaRepo(connectionString);
            bool expectedResult = true;

            TeslaModel data = new TeslaModel
            {
                Id = 12,
                Date = DateTime.Now,
                Open = 255,
                High = 255,
                Low = 257,
                Close = 255,
                Adj_Price = 255,
                Volume = 255,
                CurrentPageIndex = 1,
                TotalRecords = 12
            };

            var result = Repo.AddStockData(data);

            if (result)
                result = Repo.DeleteStockData(2485);



            Assert.AreEqual(expectedResult, result);


        }
        [TestMethod]
        public void UpdateStockData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["demo"].ToString();
            var mockDatabase = new Mock<ITeslaRepo>();
            var Repo = new TeslaRepo(connectionString);
            bool expectedResult = true;

            TeslaModel data = new TeslaModel
            {
                Id = 3243,
                Date = DateTime.Now,
                Open = 444,
                High = 444,
                Low = 444,
                Close = 444,
                Adj_Price = 444,
                Volume = 444,
                CurrentPageIndex = 1,
                TotalRecords = 12
            };

            var result = Repo.UpdateStockData(data);

            Assert.AreEqual(expectedResult, result);


        }
    }
}
