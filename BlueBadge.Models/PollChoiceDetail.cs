using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class PollChoiceDetail
    {
        public int PollId { get; set; }

        public int QuestionId { get; set; }
        public List<PollChoice> Choices { get; set; }
    }
}
