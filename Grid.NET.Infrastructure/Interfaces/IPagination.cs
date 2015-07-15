using System.Collections.Generic;

namespace Grid.NET.Infrastructure.Interfaces
{
    public interface IPagination
    {
        /// <summary>
        /// This function will be used to provide pagination for any gridview. It will return required rows for given page depenging on the page size passed.
        /// This function should also be able to try and catch any error if pageNumber does not exist.
        /// 
        /// </summary>
        /// <typeparam name="T">Type of IEnumerable to be returned.</typeparam>
        /// <param name="enumerable">This will be list , datatable or any IEnumerable of to be used for pagination.</param>
        /// <param name="pageNum">Page Number to be returned. Default value of pageNum should be 1.</param>
        /// <param name="pageSize">PageSize is kept as a parameter so that user can decide how many entries should be displayed per page.It also allows developers to use this function for different Applicaitons.</param>
        /// <returns>IEnumertable of  given type T. Returned value may then used to create gridView in views.</returns>
        IEnumerable<T> GetPageData<T>(IEnumerable<T> enumerable, int pageNum, int pageSize);

        /// <summary>
        /// getPage Counts will count total number of pages gridview can have based on Counts of IEnumrable and how many rows are to be displayed per page.
        /// This function can be used to create PageNumbwers at bottom of the gridView and when clicked on specific page Number , please call getPageData function to get data per page.
        /// </summary>
        /// <param name="enumerableCount">Count / Size of IEnumerable , e.g. array , list , datatable etc.</param>
        /// <param name="pageSize">PageSize is kept as a parameter so that user can decide how many entries should be displayed per page.It also allows developers to use this function for different Applicaitons.</param>
        /// <returns>Total Number of Pages for given IEnumerable.</returns>
        int GetPageCounts(int enumerableCount, int pageSize);

        /// <summary>
        /// GetStartingPageIndex returns integer value of what should be the starting page index that user can see. This function will be userful when user have numerous amount of pages and we
        /// have to show them specific page range.
        /// e.g. Total Page count is 10. We are showing variation of 3 pages from current page. This means for page 5 , User should see
        /// 2 3 4 5 6 7 8
        /// This function will return 2 when we pass PagNum as 5 and variation of 3. 
        /// In Other words, On GridView code should be for loop from StartPageIndx to EndPageIndex and you get StartPageIndex with this function.
        /// </summary>
        /// <param name="pageNum">Current PageNum is being displayed on a GridView.</param>
        /// <param name="variation">How many pages user should see on both side from current page.</param>
        /// <returns>StartingIndex to be displayed to User.</returns>
        int GetStartingPageIndex(int pageNum, int variation);

        /// <summary>
        /// GetLastPageIndex returns integer value of what should be the End page index that user can see. This function will be userful when user have numerous amount of pages and we
        /// have to show them specific page range.
        /// e.g. Total Page count is 10. We are showing variation of 3 pages from current page. This means for page 5 , User should see
        /// 2 3 4 5 6 7 8
        /// This function will return 8 when we pass PagNum as 5 and variation of 3. 
        /// In Other words, On GridView code should be for loop from StartPageIndx to EndPageIndex and you get EndPageIndex with this function.
        /// </summary>
        /// <param name="totalPageCount">Toal PageCount is the value of total Pages GridView can have.</param>
        /// <param name="pageNum">Current PageNum is being displayed on a GridView.</param>
        /// <param name="variation">How many pages user should see on both side from current page.</param>
        /// <returns>LastPageIndex to be displayed to User.</returns>
        int GetLastPageIndex(int totalPageCount, int pageNum, int variation);
 
    }
}