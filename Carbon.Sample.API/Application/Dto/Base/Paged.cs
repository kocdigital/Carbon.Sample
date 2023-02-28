using Carbon.PagedList;
using System.Collections.Generic;

namespace Carbon.Sample.API.Application.Dto.Base
{
    public class Paged<T> : IPagedList
    {
        public int TotalPageCount { get; set; }
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
        public int PageIndex { get; set; }
        public ICollection<T> List { get; set; }
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }
    }
}
