using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QmsCore.Model
{
    public partial class QmsStfacqError : IAssignable
    { 
        [NotMapped]
        public int Id
        {
            get { return QmsStfacqErrorId; }
            set { QmsStfacqErrorId = value; }
        }

        public string WorkItemType
        {
            get { return WorkItemTypeEnum.StaffAcquisition; }
        }
 
    }
}
