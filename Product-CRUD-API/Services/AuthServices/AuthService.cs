using Product_CRUD_API.Models;

namespace Product_CRUD_API.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> Login(UserRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.UserNameOrEmailAddress == request.UserNameOrEmailAddress);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
