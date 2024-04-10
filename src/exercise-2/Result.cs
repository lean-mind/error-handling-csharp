using LeanMind.ErrorHandling.domain;

namespace LeanMind.ErrorHandling.exercise_2;

public class Result<SuccessType>
{
    public readonly SuccessType? value;
    public readonly Error? error;

    private Result(Error? error, SuccessType? value)
    {
        this.value = value;
        this.error = error;
    }

    public bool IsSuccess()
    {
        return error == null;
    }
    
    public bool IsError()
    {
        return error != null;
    }

    public static Result<SuccessType> Success(SuccessType successValue)
    {
        return new Result<SuccessType>(null, successValue);
    }

    public static Result<SuccessType> WithError(Error error)
    {
        return new Result<SuccessType>(error, default);
    }
}
