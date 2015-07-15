using System.Collections.Generic;
using Grid.NET.Infrastructure.Implementations;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static IGrid ConvertToGrid<T>(this IEnumerable<T> enumerable) where T : class 
        {
            Grid<T> grid = new Grid<T>(enumerable);
            return grid;
        }
    }
}