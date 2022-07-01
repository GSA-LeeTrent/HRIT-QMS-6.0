using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.Model
{
    public class StaffingErrorViewPermissionEnum
    {
        public static readonly string VIEW_ALL_STFACQ_ERRORS = "VIEW_ALL_STFACQ_ERRORS";
        public static readonly string VIEW_ALL_ARCHIVE_STFACQ_ERRORS = "VIEW_ALL_ARCHIVE_STFACQ_ERRORS";
        public static readonly string VIEW_ORG_STFACQ_ERRORS = "VIEW_ORG_STFACQ_ERRORS";
        public static readonly string VIEW_ORG_ARCHIVE_STFACQ_ERRORS = "VIEW_ORG_ARCHIVE_STFACQ_ERRORS";
        public static readonly string VIEW_USER_STFACQ_ERRORS = "VIEW_USER_STFACQ_ERRORS";
        public static readonly string VIEW_USER_ARCHIVE_STFACQ_ERRORS = "VIEW_USER_ARCHIVE_STFACQ_ERRORS";
        public static readonly string EDIT_STFACQ_ERRORS = "EDIT_STFACQ_ERRORS";



    }
    /*
    set @viewAllArchivePermID = (select permission_id from aca.sec_permission where permission_code = "VIEW_ALL_ARCHIVE_ONEHR_ERRORS");
    set @viewOrgArchivePermID = (select permission_id from aca.sec_permission where permission_code = "VIEW_ORG_ARCHIVE_ONEHR_ERRORS");
    set @viewMyArchivePermID = (select permission_id from aca.sec_permission where permission_code = "VIEW_USER_ARCHIVE_ONEHR_ERRORS"); */
}
