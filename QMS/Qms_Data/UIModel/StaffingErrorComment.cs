using QmsCore.UIModel;
using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.UIModel
{
    public class StaffingErrorComment : BaseComment
    {
        public override string WorkItemType { get { return WorkItemTypeEnum.StaffAcquisition; } }

        public StaffingErrorComment(string message
                                      , int workItemId
                                      , int authorId) : base(message, workItemId, authorId)
        {
        }

        public StaffingErrorComment(QmsWorkitemcomment comment, bool enableUserSecurityLoading) : base(comment, enableUserSecurityLoading)
        {
        }


    }
}
