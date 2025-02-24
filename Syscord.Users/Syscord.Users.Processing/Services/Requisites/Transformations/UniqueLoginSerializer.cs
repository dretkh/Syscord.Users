using Syscord.Users.Core;

namespace Syscord.Users.Service.Services.Requisites.Transformations;

public sealed class UniqueLoginSerializer : ISerializer<string, UniqueLoginRequisite>
{
    public UniqueLoginRequisite Serialize(string input)
    {
        return new UniqueLoginRequisite(input.ToLower());
    }
}