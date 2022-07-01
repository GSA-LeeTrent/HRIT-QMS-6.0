using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.Model
{
    public interface IPageable<T>
    {
        int CurrentPageIndex { get; set; }
        int CurrentPageIndexDisplay { get; }
        int PageCount { get; set; }
        int TotalRecords { get; set; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

        string CurrentSort { get; set; }

        List<T> Records { get; }
    }
}