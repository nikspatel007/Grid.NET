using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations
{
    public class Column : IColumn
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string CssClass { get; set; }
        public bool IsSortable { get; set; }
        public bool IsSorted { get; set; }
        public string Width { get; set; }
    }
}