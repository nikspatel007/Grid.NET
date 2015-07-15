using System.Collections.Generic;
using System.Linq;
using Grid.NET.Infrastructure.Implementations;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Models
{
    public class PaginationModel<T>
    {
        private readonly IPagination _pagination;
        private readonly IEnumerable<T> _dataEnumerable;

        public PaginationModel(IEnumerable<T> dataEnumerable ,int pageSize, int variation)
        {
            _pagination = new Pagination();
            _dataEnumerable = dataEnumerable;
            PageSize = pageSize;
            Variation = variation;
        }

        public int PageSize { get; private set; }
        public int Variation { get; private set; }

        public int CurrentPage { get; set; }

        public int TotalRows
        {
            get { return _dataEnumerable.Count(); }
            
        }

        public int PageCount
        {
            get { return _pagination.GetPageCounts(TotalRows, PageSize); }
        }

        public int IndexStart
        {
            get { return _pagination.GetStartingPageIndex(CurrentPage, Variation); }
        }

        public int IndexEnd
        {
            get { return _pagination.GetLastPageIndex(PageCount, CurrentPage, Variation); }
        }
    }
}