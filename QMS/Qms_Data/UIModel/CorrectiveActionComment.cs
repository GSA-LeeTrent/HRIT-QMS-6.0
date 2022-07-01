using System;
using QmsCore.Model;

namespace QmsCore.UIModel
{
    public class CorrectiveActionComment : BaseComment
    {
        public override string WorkItemType {get {return Model.WorkItemTypeEnum.CorrectiveActionRequest;}}


        public CorrectiveActionComment(string message
                                      ,int workItemId
                                      ,int authorId) : base (message, workItemId, authorId)
        {
        }

        public CorrectiveActionComment(QmsWorkitemcomment comment, bool enableUserSecurityLoading) : base (comment,enableUserSecurityLoading)
        {
        }


    }//end class
}//end namespace