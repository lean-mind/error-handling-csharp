namespace LeanMind.ErrorHandling.exercise_5;


public abstract class Either<L, R>
{
    public static Either<L, R> Right(R right)
    {
        return Right<L, R>.Create(right);
    }

    public static Either<L, R> Left(L left)
    {
        return Left<L, R>.Create(left);
    }
    
    public abstract Either<L, TR> Map<TR>(Func<R, TR> f);
    public abstract Either<TL, R> MapLeft<TL>(Func<L, TL> f);
    public abstract Either<L, TR> Bind<TR>(Func<R, Either<L, TR>> f);
    public abstract Either<TL, R> BindLeft<TL>(Func<L, Either<TL, R>> f);
    public abstract T Match<T>(Func<R, T> right, Func<L, T> left);
}

class Right<L, R> : Either<L, R>
{
    private readonly R value;

    private Right(R value)
    {
        this.value = value;
    }

    public static Right<L, R> Create(R value)
    {
        return new Right<L, R>(value);
    }

    public override Either<L, TR> Map<TR>(Func<R, TR> f)
    {
        return Right<L, TR>.Create(f(value));
    }

    public override Either<TL, R> MapLeft<TL>(Func<L, TL> f)
    {
        return Right<TL, R>.Create(value);
    }

    public override Either<L, TR> Bind<TR>(Func<R, Either<L, TR>> f)
    {
        return f(value);
    }

    public override Either<TL, R> BindLeft<TL>(Func<L, Either<TL, R>> f)
    {
        return Right<TL, R>.Create(value);
    }

    public override T Match<T>(Func<R, T> right, Func<L, T> left)
    {
        return right(value);
    }
}

class Left<L, R> : Either<L, R>
{
    private readonly L value;

    private Left(L value)
    {
        this.value = value;
    }

    public static Left<L, R> Create(L value)
    {
        return new Left<L, R>(value);
    }

    public override Either<L, TR> Map<TR>(Func<R, TR> f)
    {
        return Left<L, TR>.Create(value);
    }

    public override Either<TL, R> MapLeft<TL>(Func<L, TL> f)
    {
        return Left<TL, R>.Create(f(value));
    }

    public override Either<L, TR> Bind<TR>(Func<R, Either<L, TR>> f)
    {
        return Left<L, TR>.Create(value);
    }

    public override Either<TL, R> BindLeft<TL>(Func<L, Either<TL, R>> f)
    {
        return f(value);
    }

    public override T Match<T>(Func<R, T> right, Func<L, T> left)
    {
        return left(value);
    }
}
