using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Group.Models
{
    public class GroupCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string GroupName { get; set; }
       
    }
}
