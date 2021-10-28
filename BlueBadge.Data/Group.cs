using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [ForeignKey(nameof(Question))]//creates one to many relationship
        public int? QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public List<Question> Questions = new List<Question>();

        [ForeignKey(nameof(Email))]//creates one to many relationship
        public int? EmailId { get; set; }
        public virtual Email Email { get; set; }

        public List<Email> Emails = new List<Email>();

        [Required] 
        public Guid CustomerId { get; set; }
    }
}
