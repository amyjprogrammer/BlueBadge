using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Group.Models
{
    public class GroupListItem
    {
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        public List<Question> Questions = new List<Question>();

        public List<Email> Emails = new List<Email>();
    }
}
