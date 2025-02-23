namespace Syscord.Users.Storage.Postgre;

public sealed class UserEntity
{
    public required Guid Id { get; init; }
    public required List<UserRequisiteEntity> Requisites { get; init; } = [];
}