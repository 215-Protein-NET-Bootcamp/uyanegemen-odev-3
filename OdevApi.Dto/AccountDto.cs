using OdevApi.Base.Attribute;
using OdevApi.Base.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace OdevApi.Dto
{
    public class AccountDto : BaseDto
    {
        //[Required]
        //[MaxLength(25)]
        //[Display(Name = "Id")]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(500)]
        //[UserNameAttribute]
        public string UserName { get; set; }

        //[Required]
        //[PasswordAttribute]
        public string Password { get; set; }

        //[Required]
        //[MaxLength(500)]
        public string Name { get; set; }

        //[Required]
        //[EmailAddressAttribute]
        //[MaxLength(500)]
        public string Email { get; set; }

        //[Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
