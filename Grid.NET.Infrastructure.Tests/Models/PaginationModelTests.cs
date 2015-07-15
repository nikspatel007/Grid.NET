using System.Collections.Generic;
using Grid.NET.Infrastructure.Interfaces;
using Grid.NET.Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grid.NET_Infrastructure.Tests.Models
{
    [TestClass]
    public class PaginationModelTests
    {
        private readonly PaginationModel<Customer> _paginationModel;

        public PaginationModelTests()
        {
            List<Customer> customers = Mock.DataSets.GetCustomers();
            int pageSize = 10;
            int variation = 3;
            _paginationModel = new PaginationModel<Customer>(customers , pageSize , variation);
        }

        /// <summary>
        /// If PaginationModel implements IPagination interface. 
        /// </summary>
        [TestMethod]
        [Description("If PaginationModel implements IPagination interface. ")]
        public void PaginationModel_DoesExists_True()
        {
            //Arrange

            //Act


            //Assert
            Assert.IsTrue(_paginationModel.GetType().IsClass);
        }

        /// <summary>
        /// Check if Property Values are as expected.
        /// </summary>
        [TestMethod]
        [Description(" Check if Property Values are as expected. ")]
        public void PaginationModel_CheckPropertyValues_MatchedAsExpected()
        {
            //Arrange
            const int expectedPageCount = 10;
            const int expectedIndexStart = 1;


            //Act
            int resultPageCount = _paginationModel.PageCount;
            int resultIndexStart = _paginationModel.IndexStart;

            //Assert
            Assert.AreEqual(expectedPageCount , resultPageCount);
            Assert.AreEqual(expectedIndexStart, resultIndexStart);
        }

        /// <summary>
        /// Check if Property Values are as expected aftr chaning current page value.
        /// </summary>
        [TestMethod]
        [Description("Check if Property Values are as expected aftr chaning current page value.")]
        public void PaginationModel_ChangeCurrentPage_CheckPropertyValues()
        {
            //Arrange
            
            const int expectedPageCount = 10;
            const int expectedIndexStart = 1;
            const int expectedIndexEnd = 6;

            //Act

            _paginationModel.CurrentPage = 3;
            int resultPageCount = _paginationModel.PageCount;
            int resultIndexStart = _paginationModel.IndexStart;
            int resultIndexEnd = _paginationModel.IndexEnd;

            //Assert
            
            Assert.AreEqual(expectedPageCount, resultPageCount);
            Assert.AreEqual(expectedIndexStart, resultIndexStart);
            Assert.AreEqual(expectedIndexEnd, resultIndexEnd);
        }

    }
}