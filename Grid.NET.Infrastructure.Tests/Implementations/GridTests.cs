using System.Collections.Generic;
using System.Linq;
using Grid.NET.Infrastructure.Implementations;
using Grid.NET.Infrastructure.Interfaces;
using Grid.NET.Infrastructure.Interfaces.Columns;
using Grid.NET_Infrastructure.Tests.Mock;
using Grid.NET_Infrastructure.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grid.NET_Infrastructure.Tests.Implementations
{
    [TestClass]
    public class GridTests
    {
        private readonly Grid<Customer> _grid;

        public GridTests()
        {
            List<Customer> list = DataSets.GetCustomers();
            _grid = new Grid<Customer>(list);
        }

        /// <summary>
        /// Check if Grid Implements IGRid Interface
        /// </summary>
        [TestMethod]
        [Description(" Check if Grid Implements IGRid Interface ")]
        public void Grid_ImplementsIGrid_True()
        {
            //Arrange
            Grid<Customer> grid = _grid;

            //Act


            //Assert
            Assert.IsNotNull(grid);
        }

        /// <summary>
        /// Check if Column Names are Right.
        /// </summary>
        [TestMethod]
        [Description(" Check if Column Names are Right. ")]
        public void Grid_CheckColumnNames_MatchesDisplayName()
        {
            //Arrange
            const string expectedIdColumnName = "Customer Id";

            //Act
            List<IColumn> list = _grid.Columns.ToList();
            string resultColumnName = list[0].Title;

            //Assert
            Assert.AreEqual(expectedIdColumnName , resultColumnName);
        }
    }
}