using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LMSconsole.Database.Entities
{
    public class Librarian
    {
        [Key] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
