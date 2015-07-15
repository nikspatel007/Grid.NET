using System;
using System.Collections.Generic;
using System.Linq;
using Grid.NET.Infrastructure.Extensions;
using Grid.NET.Infrastructure.Interfaces;
using Grid.NET.Infrastructure.Interfaces.Columns;

namespace Grid.NET.Infrastructure.Implementations
{
    public class Grid<T> : IGrid where T : class
    {
        #region private Variables

        private List<IColumn> _columns;

        #endregion

        #region Properties

        public IEnumerable<object> Data { get; private set; }

        public IEnumerable<IColumn> Columns
        {
            get { return _columns; }
        }

        public string EmptyGridText { get; set; }

        public string Name { get; set; }

        public bool IsSortable { get; set; }

        public bool IsPagable { get; set; }

        #endregion

        public Grid(IEnumerable<T> list)
        {
            Init(list , new Guid().ToString());
        }

        public Grid(IEnumerable<T> list , string name)
        {
            Init(list, name);           
        }

        #region Private functions

        private List<IColumn> GenerateColumns()
        {
            var type = typeof (T);
            var properties = type.GetProperties();
            foreach (var info in properties)
            {
                var displayName = PropertyExtensions.GetDisplayName(type, info, false);

                IColumn column = new Column
                {
                    Title = displayName
                };

                _columns.Add(column);
            }

            return _columns;
        }

        private void Init(IEnumerable<T> enumerable, string name)
        {
            Data = enumerable.Cast<object>().ToList();

            _columns = new List<IColumn>();
            _columns = GenerateColumns();

            EmptyGridText = "There are no rows available to display";
            Name = name;
        }

        #endregion

    }
}