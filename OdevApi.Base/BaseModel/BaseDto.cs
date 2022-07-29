using System.ComponentModel.DataAnnotations;

namespace OdevApi.Base.BaseModel
{
    public abstract class BaseDto
    {
        public DateTime CreatedAt { get; set; }

        [MaxLength(500)]
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

    }
}
