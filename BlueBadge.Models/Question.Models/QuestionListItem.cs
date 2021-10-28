using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class QuestionListItem
    {
        [Display(Name ="Question Number")]
        public int QuestionId { get; set; }

        public string Title { get; set; }

        [Display(Name ="Question")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PollQuestion { get; set; }

        [Display(Name ="Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual List<PollChoice> Choices { get; set; } = new List<PollChoice>();
    }
}
