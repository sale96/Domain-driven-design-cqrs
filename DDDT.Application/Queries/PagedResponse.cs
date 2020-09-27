using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public int PagesCount => (int) Math.Ceiling((float) TotalCount / ItemsPerPage);
        public IEnumerable<T> Items { get; set; }
    }
}
