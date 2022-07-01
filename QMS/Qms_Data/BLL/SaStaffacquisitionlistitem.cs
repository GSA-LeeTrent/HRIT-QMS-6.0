using QmsCore.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QmsCore.Model
{
    public partial class SaStaffacquisitionlistitem
    {


        [NotMapped]
        public int DaysSinceCreated {
            get {
                if (this.ResolvedAt.HasValue)
                {
                    return DateCalc.DaysBetween(this.CreatedAt, this.ResolvedAt.Value);
                }
                else
                {
                    return DateCalc.DaysBetween(this.CreatedAt, DateTime.Now);
                }
            }
        }

    }
}
