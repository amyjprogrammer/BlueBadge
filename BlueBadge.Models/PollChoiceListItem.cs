using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class PollChoiceListItem
    {
        [Display(Name = "Poll Id Number")]
        public int PollId { get; set; }

        [Display(Name = "Question Id Number")]
        public int QuestionId { get; set; }

        [Display(Name = "Question Choices")]
        public List<PollChoice> Choices { get; set; }
    }
}
