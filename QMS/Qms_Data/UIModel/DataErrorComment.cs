using System;
using QmsCore.Model;

namespace QmsCore.UIModel
{
    public class DataErrorComment : BaseComment
    {
        public override string WorkItemType {get {return Model.WorkItemTypeEnum.EHRI;}}

        
        public DataErrorComment(string message
                                      ,int workItemId
                                      ,int authorId) : base (message,workItemId,authorId)
        {
        }

        public DataErrorComment(QmsWorkitemcomment comment, bool enableUserSecurityLoading) : base (comment,enableUserSecurityLoading)
        {
        }


    }//end class
}//end namespace