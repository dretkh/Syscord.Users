namespace Syscord.Users.Service.Services.Requisites.Pipelines;

public interface IPipelineStage<in TIn, TOut>
{
    Task<TOut> HandleAsync(TIn input);
}