using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grid.NET.Infrastructure.Interfaces.Columns;

namespace Grid.NET.Infrastructure.Interfaces
{
    public interface IGrid
    {
        IEnumerable<object> Data { get; }

        IEnumerable<IColumn> Columns { get; }

        string EmptyGridText { get; set; }

        string Name { get; set; }

        bool IsSortable { get; set; }

        bool IsPagable { get; set; }
    }
}