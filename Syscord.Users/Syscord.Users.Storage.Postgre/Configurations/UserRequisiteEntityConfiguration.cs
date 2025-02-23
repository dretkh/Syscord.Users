using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syscord.Users.Storage.Postgre.Configurations;

public sealed class UserRequisiteEntityConfiguration : IEntityTypeConfiguration<UserRequisiteEntity>
{
    public void Configure(EntityTypeBuilder<UserRequisiteEntity> builder)
    {
        builder.HasKey(
            x => new
            {
                x.UserId,
                x.Name
            });

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Requisites)
            .HasForeignKey(x => x.UserId);
    }
}