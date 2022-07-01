using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.UIModel
{
    public class BaseComment
    {
        public int Id { get; set; }
        public int WorkItemId { get; set; }
        public string Message { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual string WorkItemType { get { return string.Empty; } }
        public User Author { get; set; }

        public BaseComment()
        { }

        public BaseComment(string message, int workItemId, int authorId)
        {
            this.Message = message;
            this.WorkItemId = workItemId;
            this.AuthorId = authorId;
            this.CreatedAt = DateTime.Now;
        }


        public BaseComment(QmsWorkitemcomment comment, bool enableUserSecurityLoading)
        {
            this.Id = comment.Id;
            this.WorkItemId = comment.WorkItemId.Value;
            this.Message = comment.Message;
            this.CreatedAt = comment.CreatedAt;
            this.AuthorId = (int)comment.AuthorId.Value;
            this.Author = new User(comment.Author, enableUserSecurityLoading);
        }


        public QmsWorkitemcomment WorkItemComment()
        {
            QmsWorkitemcomment workItemComment = new QmsWorkitemcomment();
            workItemComment.Id = this.Id;
            workItemComment.WorkItemId = this.WorkItemId;
            workItemComment.AuthorId = (uint)this.AuthorId;
            workItemComment.CreatedAt = this.CreatedAt;
            workItemComment.Message = this.Message;
            workItemComment.WorkItemTypeCode = this.WorkItemType;
            return workItemComment;
        }

    }
}
