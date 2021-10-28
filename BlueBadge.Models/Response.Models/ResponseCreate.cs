using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class ResponseCreate
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int PollId { get; set; }
    }
}
