using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QmsCore.Model
{
    public partial class NtfNotification
    {

        /// <summary>
        /// Wrapper to implement IAssignable due to ef scaffolding change
        /// </summary>
        [NotMapped]
        public sbyte HasBeenRead
        {
            get { return this.Hasbeenread; }
            set { this.Hasbeenread = value; }
        }

        /// <summary>
        /// Wrapper to implement IAssignable due to ef scaffolding change
        /// </summary>
        [NotMapped]
        public sbyte SendAsEmail
        {
            get { return this.Sendasemail; }
            set { this.Sendasemail = value; }
        }


        public NtfNotification()
        {

            this.HasBeenRead = 0;
            this.SendAsEmail = 0;
        }
        public NtfNotification Clone()
        {
            NtfNotification retval = new NtfNotification();
            retval.CreatedAt = this.CreatedAt;
            retval.DeletedAt = this.DeletedAt;
            retval.HasBeenRead = this.HasBeenRead;
            retval.Message = this.Message;
            retval.Title = this.Title;
            retval.NotificationEventId = this.NotificationEventId;
            retval.ReadAt = this.ReadAt;
            retval.SendAsEmail = this.SendAsEmail;
            retval.SentAt = this.SentAt;
            retval.UserId = this.UserId;
            retval.WorkitemId = this.WorkitemId;
            retval.WorkItemTypeCode = this.WorkItemTypeCode;
            return retval;

        }
    }//end class
}//end namespace
