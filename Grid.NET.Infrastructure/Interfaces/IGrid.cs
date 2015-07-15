using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grid.NET.Infrastructure.Models;

namespace Grid.NET.Infrastructure.Interfaces
{
    public interface IGrid
    {
        #region Getters

        IEnumerable<object> Data { get; }

        PaginationModel<object> Pagination { get; }

        IEnumerable<IColumn> Columns { get; }

        bool IsPagingEnabled { get; }

        #endregion

        #region Properties

        string EmptyGridText { get; set; }

        string Name { get; set; }

        bool IsSortable { get; set; }

        #endregion

        #region Functions

        void WithPageSize(int pageSize, int variation = 3);

        #endregion

    }
}