using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class ResponseDetail
    {
        public int ResponseId { get; set; }

        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        [ForeignKey(nameof(PollChoice))]
        public int PollId { get; set; }
        public virtual PollChoice PollChoice { get; set; }
    }
}
