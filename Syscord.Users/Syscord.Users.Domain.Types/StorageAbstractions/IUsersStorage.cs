using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Optional;

namespace Syscord.Users.Domain.Types.StorageAbstractions;

public interface IUsersStorage
{
    Task CreateAsync(User user, CancellationToken token);
    Task<Option<User>> GetAsync(Guid id, CancellationToken token);
    IAsyncEnumerable<User> GetAllAsync(CancellationToken token);
}