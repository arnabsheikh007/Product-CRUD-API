namespace Product_CRUD_API.Models
{
    public class User
    {
        public int TenantId { get; set; }
        public string UserNameOrEmailAddress { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
    }
}
