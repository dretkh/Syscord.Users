using Optional;

namespace Syscord.Users.Service.Storages;

public interface IUsersStorage
{
    Task CreateAsync(User user, CancellationToken token);
    Task<Option<User>> GetAsync(Guid id, CancellationToken token);
}