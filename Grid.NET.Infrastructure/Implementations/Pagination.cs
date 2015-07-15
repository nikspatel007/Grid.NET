using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Infrastructure.Implementations
{
    public class Pagination : IPagination
    {
        /// <summary>
        /// GetPageData returns Paged Data for specific Page.
        /// This function is safe enough to figure out that lets say if 34 counts are given for page size of 5 and if user click on page number 7.
        /// It will return last 4 rows and will not throw out of bound exception.
        /// </summary>
        /// <typeparam name="T">Object Type to be Returned as IEnumerable.</typeparam>
        /// <param name="enumerable">IEnumerable of Type T</param>
        /// <param name="pageNum">PageNum to be displayed. PAgeNum helps to see where to start getting data.</param>
        /// <param name="pageSize">Rows Displayed per Page.</param>
        /// <returns>Paged IEnumerable of Type T.</returns>
        public IEnumerable<T> GetPageData<T>(IEnumerable<T> enumerable, int pageNum, int pageSize)
        {
            if (!enumerable.Any())
            {
                return enumerable;
            }
            else
            {
                return enumerable.Skip((pageNum - 1) * pageSize).Take(pageSize);
            }
        }

        /// <summary>
        /// Return Total Number of Pages GridView needs to display Based on PageSize and Count passed..
        /// </summary>
        /// <param name="enumerableCount">Size of DataSource.</param>
        /// <param name="pageSize">Rows per page.</param>
        /// <returns>Count of PageNumber to be displayed.</returns>
        public int GetPageCounts(int enumerableCount, int pageSize)
        {
            int ret = (enumerableCount > 0) ? enumerableCount : 0;
            double temp = (pageSize == 0) ? 0.00 : (ret / pageSize);

            return (ret % pageSize == 0) ? (ret / pageSize) : ((int)(Math.Floor(temp)) + 1); ;
        }

        /// <summary>
        /// GetTheFinalPageIndex using following pesuedo code.
        /// if pageNum minus Variation is less than 1
        ///     then Return 1
        /// else
        ///     Return PageNum minus Variation.
        /// </summary>
        /// <param name="pageNum">Current PageNum is being displayed on a GridView.</param>
        /// <param name="variation">How many pages user should see on both side from current page.</param>
        /// <returns>StartingIndex to be displayed to User.</returns>
        public int GetStartingPageIndex(int pageNum, int variation)
        {
            return ((pageNum - variation) <= 1) ? 1 : (pageNum - variation);
        }

        /// <summary>
        /// GetTheFinalPageIndex using following pesuedo code.
        /// if pageNum plus Variation is greater than totalPage count 
        ///     then Return TotalPageCount
        /// else
        ///     Return PageNum plus Variation.
        /// </summary>
        /// <param name="totalPageCount">Toal PageCount is the value of total Pages GridView can have.</param>
        /// <param name="pageNum">Current PageNum is being displayed on a GridView.</param>
        /// <param name="variation">How many pages user should see on both side from current page.</param>
        /// <returns>LastPageIndex to be displayed to User.</returns>
        public int GetLastPageIndex(int totalPageCount, int pageNum, int variation)
        {
            return ((pageNum + variation) >= totalPageCount) ? totalPageCount : (pageNum + variation);
        }
    }
}
