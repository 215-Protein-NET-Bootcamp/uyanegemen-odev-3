using OdevApi.Base.BaseModel;

namespace OdevApi.Data.Model
{
    public class Person : BaseModel
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
