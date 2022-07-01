using System;
using System.Collections.Generic;
using  QmsCore.UIModel;

namespace QmsCore.Model
{
    public interface IAssignable
    {
        int Id {get;set;}
        DateTime CreatedAt { get; set; }
        uint? AssignedByUserId { get; set; }
        uint? AssignedToUserId { get; set; }
        uint? AssignedToOrgId { get; set; }
        DateTime? AssignedAt { get; set; }
        uint? StatusId { get; set; }
        DateTime? SubmittedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? ResolvedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        string WorkItemType { get; }    
        uint? CreatedByUserId { get; set; }   
    }
}