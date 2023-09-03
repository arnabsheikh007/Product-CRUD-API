namespace Product_CRUD_API.Models
{
    public class UserRequest
    {
        public required string UserNameOrEmailAddress { get; set; }
        public required string Password { get; set; }
    }
}
