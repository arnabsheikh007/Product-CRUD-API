namespace Product_CRUD_API.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> Register(User user);
        Task<User?> Login(UserRequest request);

    }
}
