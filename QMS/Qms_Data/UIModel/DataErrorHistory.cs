using System;
using System.Collections.Generic;

namespace QmsCore.UIModel
{
    public class DataErrorHistory : BaseHistory
    {
        public override string WorkItemType { get { return QmsCore.Model.WorkItemTypeEnum.EHRI; } }
        public DataErrorHistory(QmsCore.Model.QmsWorkitemhistory history) :base(history)
        {


        }

    }
}
