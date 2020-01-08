using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:8,MinimumLength =4, ErrorMessage = "Name length can't be more than 8 and less than 4.")]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string State { get; set; }
        public DateTime ? DateCreated { get; set; }
    }
}
