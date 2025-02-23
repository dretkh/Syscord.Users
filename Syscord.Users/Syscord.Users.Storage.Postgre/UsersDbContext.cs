using Microsoft.EntityFrameworkCore;

namespace Syscord.Users.Storage.Postgre;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRequisiteEntity> UserRequisites { get; set; }
}