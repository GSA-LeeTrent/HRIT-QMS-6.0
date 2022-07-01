using Qms_Data.Model;
using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.Model
{
    public class StaffingErrorListItemPager : IPageable<SaStaffacquisitionlistitem>
    {
        public List<SaStaffacquisitionlistitem> Records { get; set; }
        public string CurrentSort { get; set; }
        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }

        public int CurrentPageIndexDisplay { get { return CurrentPageIndex + 1; } }

        public int PageCount { get; set; }

        public int TotalRecords { get; set; }

        public void SetPagerInfo(int pageSize, int totalRecords, int pageNumber)
        {
            PageSize = pageSize;
            TotalRecords = totalRecords;
            CurrentPageIndex = pageNumber;
            decimal pageCount = totalRecords / pageSize;
            int x = (totalRecords % pageSize) > 0 ? 1 : 0;
            PageCount = (int)pageCount + x;
        }




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
                return  PageCount == 1 ? false : CurrentPageIndex < PageCount;
            }
        }
    }

}

