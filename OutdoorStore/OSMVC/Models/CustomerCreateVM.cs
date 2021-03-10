using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSMVC.Models
{
    public class CustomerCreateVM
    {
        [Required]
        public string Name { get; set; }

        [DisplayName("Home Address")]
        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
