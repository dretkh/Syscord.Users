using Microsoft.EntityFrameworkCore;
using Optional;
using Optional.Collections;
using Syscord.Users.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre.Implementations;

public sealed class UsersStorage(UsersDbContext dbContext, IConverter<User, UserEntity> userConverter) : IUsersStorage
{
    public async Task<bool> IsUniqueRequisiteValueTakenAsync(string name, string value, CancellationToken token)
        => await dbContext.UserRequisites
            .AnyAsync(x => x.Name == name && x.Value == value, token);

    public async Task CreateAsync(User user, CancellationToken token)
    {
        dbContext.Add(userConverter.Serialize(user));
        await dbContext.SaveChangesAsync(token).ConfigureAwait(false);
    }

    public async Task<Option<User>> GetAsync(Guid id, CancellationToken token)
    {
        var result = await dbContext.Users
            .Where(x => x.Id == id)
            .Include(x => x.Requisites)
            .AsNoTracking()
            .AsAsyncEnumerable()
            .Select(userConverter.Deserialize)
            .ToListAsync(token);

        return result.FirstOrNone();
    }

    public IAsyncEnumerable<User> GetAllAsync()
        => dbContext.Users
            .Include(x => x.Requisites)
            .AsNoTracking()
            .AsAsyncEnumerable()
            .Select(userConverter.Deserialize);
}