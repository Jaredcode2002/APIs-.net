
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync(); // Obtener todos los usuarios
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id); // Buscar usuario por ID
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user); // Agregar nuevo usuario
        var changes = await _context.SaveChangesAsync(); // Guardar cambios
        return changes > 0;
    }

    public async Task<bool> UpdateUserAsync(int id, User user)
    {
        var userexist = await _context.Users.FindAsync(id);
        if (userexist != null)
        {
            userexist.nombre = user.nombre;
            userexist.contrasenia = user.contrasenia;

            // Guardar los cambios en la base de datos
            var changes = await _context.SaveChangesAsync();
            return changes > 0; // Devolver true si hubo cambios
        }
        return false; // Si el usuario no existe
    }


    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user); // Eliminar usuario
            var changes = await _context.SaveChangesAsync(); // Guardar cambios
            return changes > 0; // Devolver true si hubo cambios
        }
        return false;
    }


}

