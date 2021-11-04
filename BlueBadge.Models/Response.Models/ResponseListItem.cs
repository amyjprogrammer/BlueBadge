using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Response.Models
{
    public class ResponseListItem
    {
        [Display(Name = "Response Id Number")]
        public int ResponseId { get; set; }

        [Display(Name = "Poll Id Number")]
        public int PollId { get; set; }

        [Display(Name = "Times Selected")]
        public int Selected { get; set; }
    }
}
