using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Response
    {
        private int _selected = 1;
        [Key]
        public int ResponseId { get; set; }

        [ForeignKey(nameof(PollChoice))]
        public int PollId { get; set; }
        public virtual PollChoice PollChoice { get; set; }

        public virtual List<PollChoice> Choice { get; set; } = new List<PollChoice>();

        public int Selected { get { return _selected; } set { _selected = value; } }
    }
}
