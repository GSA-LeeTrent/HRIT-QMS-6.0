using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using QmsCore.Lib;

namespace QmsCore.Model
{
    public partial class QmsCorrectiveactionrequest : IAssignable, ITimeTrackable
    {
        /// <summary>
        /// Wrapper to implement IAssignable due to ef scaffolding change
        /// </summary>
        [NotMapped]
        public DateTime? AssignedAt
        {
            get { return this.Assignedat; }
            set { this.Assignedat = value; }
        }

        /// <summary>
        /// Wrapper to implement IAssignable due to ef scaffolding change
        /// </summary>
        [NotMapped]
        public DateTime? UpdatedAt
        {
            get { return this.Updatedat; }
            set { this.Updatedat = value; }
        }

        /// <summary>
        /// Wrapper to implement IAssignable due to ef scaffolding change
        /// </summary>
        [NotMapped]
        public DateTime? ResolvedAt
        {
            get { return this.Resolvedat; }
            set { this.Resolvedat = value; }
        }

        /// <summary>
        /// Wrapper to implement IAssignable due to ef scaffolding change
        /// </summary>
        [NotMapped]
        public DateTime? DeletedAt
        {
            get { return this.Deletedat; }
            set { this.Deletedat = value; }
        }

        [NotMapped]
        public int DaysSinceCreated {
            get {
                return DateCalc.DaysBetween(this.CreatedAt, DateTime.Now);
            }
        }

        [NotMapped]
        public int? DaysSinceAssigned{
            get {
                return DateCalc.DaysBetween(this.AssignedAt.Value, DateTime.Now);
            }
        }

        [NotMapped]
        public string WorkItemType {
            get {
                return Model.WorkItemTypeEnum.CorrectiveActionRequest;
            }
        }


    }
}