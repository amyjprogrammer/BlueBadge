using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class QuestionCreate
    {
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage ="There are too many characters for the Title Field.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string PollQuestion { get; set; }

        public string UserFullName { get; set; }
    }
}
