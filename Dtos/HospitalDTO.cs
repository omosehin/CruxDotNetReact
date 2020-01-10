using CruxDotNetReact.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CruxDotNetReact.Dtos
{
    public class HospitalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Name length can't be more than 8 and less than 4.")]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string State { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
