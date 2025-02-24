using Microsoft.AspNetCore.Mvc;
using Syscord.Users.Core;
using Syscord.Users.Service.Services;
using Syscord.Users.Service.Services.Requests;
using Syscord.Users.WebApi.V1.Types;
using DomainUser = Syscord.Users.Domain.Types.User;

namespace Syscord.Users.WebApi.V1;

[Route("v1/users")]
public sealed class UsersController(
    IUsersRequestsService usersRequestsService,
    IConverter<DomainUser, ApiUser> userApiConverter) : Controller
{
    // private static readonly Dictionary<Guid, DomainUser> users = new();

    [Route("{id:guid}")]
    [HttpGet]
    public async Task<ApiUser> GetByIdAsync(Guid id)
    {
        var user = await usersRequestsService.GetAsync(id, default);

        return user.Match(
            some: userApiConverter.Serialize,
            none: () => throw new IllegalProgramException());
    }

    [Route("")]
    [HttpPost]
    public async Task CreateUserAsync(string login)
    {
        await usersRequestsService.CreateAsync(new UserCreationRequest(login), default);
    }

    [Route("")]
    [HttpGet]
    public async Task<IReadOnlyCollection<ApiUser>> GetAllAsync()
        => await usersRequestsService.GetAllAsync(default).Select(userApiConverter.Serialize).ToListAsync();
}