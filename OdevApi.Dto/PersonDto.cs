using OdevApi.Base.Attribute;
using OdevApi.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevApi.Dto
{
    public class PersonDto : BaseDto
    {
        [Required]
        [MaxLength(25)]
        [Display(Name = "AccountId")]
        public int AccountId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(500)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [DateOfBirth]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}
