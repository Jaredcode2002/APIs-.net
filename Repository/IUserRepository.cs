public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync(); //Task --> clase de .NET para definir operaciones asincronas
    Task<User> GetUserByIdAsync(int id);
    Task<bool> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(int id, User user);
    Task<bool> DeleteUserAsync(int id);
}