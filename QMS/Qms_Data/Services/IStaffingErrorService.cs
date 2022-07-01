using Qms_Data.UIModel;
using QmsCore.Model;
using QmsCore.UIModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.Services
{
    public interface IStaffingErrorService
    {
        void SaveComment(string message, int entityId, int authorId);
        void Close(StaffingError error);
        List<UIModel.StaffingErrorComment> RetrieveComments(int staffingErrorId);
        StaffingError RetrieveById(int id);
        StaffingErrorListItemPager GetActiveRecordsAll(string orderBy, int pageNumber, int pageSize);
        StaffingErrorListItemPager GetArchiveRecordsAll(string orderBy, int pageNumber, int pageSize);
        StaffingErrorListItemPager GetActiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize);
        StaffingErrorListItemPager GetArchiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize);
        StaffingErrorListItemPager GetActiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize);
        StaffingErrorListItemPager GetArchiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize);

    }
}
