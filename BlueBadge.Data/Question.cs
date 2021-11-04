using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required] 
        public Guid CustomerId { get; set; }

        public string Title { get; set; }

        public virtual List<PollChoice> Choices { get; set; } = new List<PollChoice>();

        [Required]
        public string PollQuestion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUtc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(UserFullName))]
        public string FullName { get; set; }
        public virtual ApplicationUser UserFullName { get; set; }
    }
}
