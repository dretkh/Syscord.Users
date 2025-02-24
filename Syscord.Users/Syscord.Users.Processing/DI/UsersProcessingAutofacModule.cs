using Autofac;
using Syscord.Users.Service.Services;
using Syscord.Users.Service.Services.Requisites.Transformations;
using Syscord.Users.Service.Services.Requisites.Validations;
using Syscord.Users.Storage.Postgre.DI;

namespace Syscord.Users.Service.DI;

public sealed class UsersProcessingAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterModule(new PostgreStorageAutofacModule());
        builder.RegisterType<UsersRequestsService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<UniqueLoginSerializer>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<LoginFormatValidator>().AsImplementedInterfaces().SingleInstance();
    }
}