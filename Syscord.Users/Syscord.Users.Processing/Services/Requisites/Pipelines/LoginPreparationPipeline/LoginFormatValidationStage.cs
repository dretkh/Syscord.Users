using Syscord.Users.Core;

namespace Syscord.Users.Service.Services.Requisites.Pipelines.LoginPreparationPipeline;

public sealed class LoginFormatValidationStage : IPipelineStage<string, Result<string, None>>
{
    public Task<Result<string, None>> HandleAsync(string input)
    {
        return string
    }
}