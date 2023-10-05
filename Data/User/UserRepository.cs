using Domain.User.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.User;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public UserRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<int> CreateAsync(Domain.User.Entities.User user)
    {
        await _libraryDbContext
            .Users
            .AddAsync(user);

        await _libraryDbContext
            .SaveChangesAsync();

        return user.Id;
    }

    public async Task DeleteUserAsync(Domain.User.Entities.User user)
    {
        _libraryDbContext
            .Users
            .Remove(user);

        await _libraryDbContext
            .SaveChangesAsync();
    }

    public async Task<Domain.User.Entities.User> GetUserByIdAsync(int id)
    {
        return await _libraryDbContext
            .Users
            .FirstOrDefaultAsync(x => x.Id == id) ?? new();
    }

    public async Task<List<Domain.User.Entities.User>> GetUsers()
    {
        return await _libraryDbContext
            .Users
            .ToListAsync();
    }

    public async Task<Domain.User.Entities.User> UpdateUser(Domain.User.Entities.User user)
    {
        _libraryDbContext
            .Users
            .Update(user);

        await _libraryDbContext
            .SaveChangesAsync();

        return user;
    }
}
