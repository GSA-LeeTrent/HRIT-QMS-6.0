using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.UIModel
{
    public class StaffingErrorHistory : BaseHistory
    {
        public override string WorkItemType { get { return QmsCore.Model.WorkItemTypeEnum.StaffAcquisition; } }
        public StaffingErrorHistory(QmsCore.Model.QmsWorkitemhistory history) : base(history)
        {


        }
    }
}
