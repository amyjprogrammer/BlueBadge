using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required] // Gerald The Bouncer //
        public Guid CustomerId { get; set; }

        public string Title { get; set; }

        [Required]
        public string PollQuestion { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
