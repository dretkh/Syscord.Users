namespace Syscord.Users.Core;

public abstract class Result<TValue, TError>
{
    public static Success AsSuccess(TValue value) => new(value);
    public static Fail AsFail(TError error) => new(error);
    
    public abstract TValue Value { get; }
    public abstract TError Error { get; }

    public bool IsSuccess() => this is Success;
    public bool IsFail() => this is Fail;
    
    public sealed class Success(TValue value) : Result<TValue, None>
    {
        public override TValue Value { get; } = value;
        public override None Error => throw new IllegalProgramException();
    }

    public sealed class Fail(TError error) : Result<TValue, TError>
    {
        public override TValue Value => throw new IllegalProgramException();
        public override TError Error { get; } = error;
    }
}