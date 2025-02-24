using Optional;
using Syscord.Users.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;
using Syscord.Users.Service.Services.Requests;
using Syscord.Users.Service.Services.Requisites;

namespace Syscord.Users.Service.Services;

public sealed class UsersRequestsService(
    IUsersStorage storage,
    IValidator<string, None>
    ISerializer<string, UniqueLoginRequisite> uniqueLoginSerializer) : IUsersRequestsService
{
    public async Task CreateAsync(UserCreationRequest request, CancellationToken token)
    {
        ValidateRequest(request);
        
        
        if(await IsLoginTakenAsync(request.Login))
        
        var user = User.Create(new Dictionary<string, string>
        {
            { RequisiteNames.Login, request.Login }
        });

        await storage.CreateAsync(user, token);
    }

    public async Task<Option<User>> GetAsync(Guid id, CancellationToken token) => await storage.GetAsync(id, token);

    public IAsyncEnumerable<User> GetAllAsync()
        => storage.GetAllAsync();
    private static void ValidateRequest(UserCreationRequest request)
    {
        if (string.IsNullOrEmpty(request.Login))
        {
            throw new IllegalProgramException();
        }
    }

    private async Task<bool> IsLoginTakenAsync(string login, CancellationToken token)
        => await storage.IsUniqueRequisiteValueTakenAsync(RequisiteNames.Login, login, token);
}