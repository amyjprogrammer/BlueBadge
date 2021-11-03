using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Group.Models
{
    public class GroupDetail
    {
        [Display(Name = "Group Number")]
        public int GroupId { get; set; }

        [Display(Name ="Group Name")]
        public string GroupName { get; set; }

        public List<QuestionListItem> Questions = new List<QuestionListItem>();

        public List<EmailListItem> Emails = new List<EmailListItem>();
    }
}
