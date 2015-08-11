using System.Collections.Generic;
using Grid.NET.Infrastructure.Implementations;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static IGrid ConvertToGrid<T>(this IEnumerable<T> enumerable , string gridName , int pageSize = 8 , int pageVariation = 3) where T : class
        {
            IGrid grid = new Grid<T>(enumerable, gridName)
                .WithPageSize(pageSize , pageVariation);
            return grid;
        }
    }
}