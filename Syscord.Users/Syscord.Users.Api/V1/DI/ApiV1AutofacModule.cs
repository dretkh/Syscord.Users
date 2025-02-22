using Autofac;
using Syscord.Users.Api.V1.Converters;

namespace Syscord.Users.Api.V1.DI;

public sealed class ApiV1AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<ApiUserConverter>().AsImplementedInterfaces().AsSelf();
    }
}