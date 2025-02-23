using Microsoft.EntityFrameworkCore;
using Optional;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;

namespace Syscord.Users.Storage.Postgre.Implementations;

public sealed class UsersStorage(UsersDbContext dbContext) : IUsersStorage
{
    public async Task CreateAsync(User user, CancellationToken token)
    {
    }

    public async Task<Option<User>> GetAsync(Guid id, CancellationToken token)
    {
        var x = await dbContext.UserRequisites.ToListAsync(token);
        return new User(id, new Dictionary<string, string>()).Some();
    }

    public IAsyncEnumerable<User> GetAllAsync(CancellationToken token)
    {
        return AsyncEnumerable.Empty<User>();
    }
}