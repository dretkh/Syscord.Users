using Microsoft.AspNetCore.Mvc;
using Syscord.Users.Api.V1.Types;
using Syscord.Users.Core;
using DomainUser = Syscord.Users.User;

namespace Syscord.Users.Api.V1;

[Route("v1/users")]
public sealed class UsersController(IFormat<DomainUser, ApiUser> userApiFormat) : Controller
{
    private static readonly Dictionary<Guid, DomainUser> users = new();

    [Route("{id:guid}")]
    [HttpGet]
    public Task<ApiUser> GetByIdAsync(Guid id)
    {
        if (users.TryGetValue(id, out var user))
        {
            return Task.FromResult(userApiFormat.Serialize(user));
        }

        throw new IllegalProgramException();
    }

    [Route("")]
    [HttpPost]
    public Task CreateUserAsync(string login)
    {
        var user = DomainUser.Create(new Dictionary<string, string>
        {
            { Requisites.Login, login }
        });
        users.Add(user.Id, user);
        return Task.CompletedTask;
    }

    [Route("")]
    [HttpGet]
    public Task<IEnumerable<ApiUser>> GetAllAsync() => Task.FromResult(users.Values.Select(userApiFormat.Serialize));
}