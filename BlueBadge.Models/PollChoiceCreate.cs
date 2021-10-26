using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class PollChoiceCreate
    {
        [MinLength(1, ErrorMessage = "Please enter at least one characters for that choice.")]
        [MaxLength(250, ErrorMessage = "Choice Answers must be no longer than 250 characters.")]
        public List<PollChoice> Choices { get; set; }
    }
}
