using System;

namespace Grid.NET.Infrastructure.Implementations.Filter
{
    public class FiltrationAttribute : Attribute
    {

        public FiltrationAttribute(Enums.FilterType filterType)
        {
            Filter = filterType;
        }

        public readonly Enums.FilterType Filter;

    }
}