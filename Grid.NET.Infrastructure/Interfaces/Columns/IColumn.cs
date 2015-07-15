namespace Grid.NET.Infrastructure.Interfaces.Columns
{
    public interface IColumn
    {
        string Title { get; set; }

        string Name { get; set; }

        string CssClass { get; set; }

        bool IsSortable { get; set; }

        bool IsSorted { get; set; }

        string Width { get; set; }

    }
}