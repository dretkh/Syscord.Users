using Optional;
using Syscord.Users.Domain.Types;
using Syscord.Users.Service.Services.Requests;

namespace Syscord.Users.Service.Services;

public interface IUsersRequestsService
{
    Task CreateAsync(UserCreationRequest request, CancellationToken token);
    Task<Option<User>> GetAsync(Guid id, CancellationToken token);
    IAsyncEnumerable<User> GetAllAsync();
}