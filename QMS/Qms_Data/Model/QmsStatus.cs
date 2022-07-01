using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsStatus
    {
        public QmsStatus()
        {
            QmsCorrectiveactionrequest = new HashSet<QmsCorrectiveactionrequest>();
            QmsDataerror = new HashSet<QmsDataerror>();
            QmsStatusTransFromStatus = new HashSet<QmsStatusTrans>();
            QmsStatusTransToStatus = new HashSet<QmsStatusTrans>();
            QmsStfacqError = new HashSet<QmsStfacqError>();
            QmsWorkitemhistory = new HashSet<QmsWorkitemhistory>();
        }

        public uint StatusId { get; set; }
        public string StatusCode { get; set; }
        public string StatusLabel { get; set; }
        public uint DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequest { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerror { get; set; }
        public virtual ICollection<QmsStatusTrans> QmsStatusTransFromStatus { get; set; }
        public virtual ICollection<QmsStatusTrans> QmsStatusTransToStatus { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqError { get; set; }
        public virtual ICollection<QmsWorkitemhistory> QmsWorkitemhistory { get; set; }
    }
}
