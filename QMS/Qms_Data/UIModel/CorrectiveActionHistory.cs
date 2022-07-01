using System;
using System.Collections.Generic;

namespace QmsCore.UIModel
{
    public class CorrectiveActionHistory : BaseHistory
    {
        public override string WorkItemType { get { return QmsCore.Model.WorkItemTypeEnum.CorrectiveActionRequest; } }

        public CorrectiveActionHistory(QmsCore.Model.QmsWorkitemhistory history) : base(history)
        {                

        }

    }
}
