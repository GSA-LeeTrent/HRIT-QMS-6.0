using System;
using System.Collections.Generic;
using System.Text;

namespace Qms_Data.Model
{
    public class EmployeeCategorizationChaseListItemPager : IPageable<EmployeeCategorizationChaseListItem>
    {
        public List<EmployeeCategorizationChaseListItem> Records { get; set; }
        public string CurrentSort { get; set; }

        public int CurrentPageIndex { get; set; }

        public int CurrentPageIndexDisplay { get { return CurrentPageIndex + 1; } }

        public int PageCount { get; set; }

        public int TotalRecords { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return CurrentPageIndex < PageCount;
            }
        }
    }
}