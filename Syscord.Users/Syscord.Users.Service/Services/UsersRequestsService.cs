using Optional;
using Syscord.Users.Core;
using Syscord.Users.Service.Services.Requests;
using Syscord.Users.Service.Storages;

namespace Syscord.Users.Service.Services;

public sealed class UsersRequestsService(IUsersStorage storage) : IUsersRequestsService
{
    public async Task CreateAsync(UserCreationRequest request, CancellationToken token)
    {
        ValidateRequest(request);
        var user = User.Create(new Dictionary<string, string>
        {
            { Requisites.Login, request.Login }
        });

        await storage.CreateAsync(user, token);
    }

    public async Task<Option<User>> GetAsync(Guid id, CancellationToken token) => await storage.GetAsync(id, token);

    private static void ValidateRequest(UserCreationRequest request)
    {
        if (string.IsNullOrEmpty(request.Login))
        {
            throw new IllegalProgramException();
        }
    }
}