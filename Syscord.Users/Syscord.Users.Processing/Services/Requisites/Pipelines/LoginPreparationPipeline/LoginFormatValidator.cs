using Syscord.Users.Core;

namespace Syscord.Users.Service.Services.Requisites.Pipelines.LoginPreparationPipeline;

public sealed class LoginFormatValidator : IValidator<string, None>
{
    public Result<string, None> Validate(string input)
        => string.IsNullOrEmpty(input)
            ? Result<string, None>.AsFail(new None())
            : Result<string, None>.AsSuccess(input);
}