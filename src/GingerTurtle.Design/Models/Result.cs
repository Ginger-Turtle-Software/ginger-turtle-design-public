namespace GingerTurtle.Design.Models;

public record Result<T>(bool IsSuccessful, string ErrorReference = null, T Value = default)
{
    public Result<TResult> ToFailed<TResult>() => Result<TResult>.Failed(ErrorReference);
    public static Result<T> Failed(string errorReference = null) => new(false, errorReference);
    public static implicit operator Result<T>(T value) => new (true, Value: value);
}
