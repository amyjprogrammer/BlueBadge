using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Email
    {
        private string _firstName;
        private string _lastName;

        [Key]
        public int EmailId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("First Name must be at least one character in the alphabet with no special characters.");
                else
                    _firstName = value;
            }
        }

        [Required]
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("Last Name must be at least one character in the alphabet with no special characters.");
                else
                    _lastName = value;
            }
        }

        public string EmailAddress { get; set; }
    }
}
