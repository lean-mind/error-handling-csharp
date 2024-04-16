using FluentAssertions;
using Xunit;

namespace LeanMind.ErrorHandling.exercise_5;

public class EitherShould
{
    [Fact]
    public void BuildARightValue()
    {
        var value = Either<string, int>.Right(2);

        value.Match(
            rightValue => rightValue.Should().Be(2),
            _ => throw new Exception("Should be right, got left")
        );
    }
    
    [Fact]
    public void BuildALeftValue()
    {
        var value = Either<string, int>.Left("10");

        value.Match(
            _ => throw new Exception("Should be left, got right"),
            leftValue => leftValue.Should().Be("10")
        );
    }

    [Fact]
    public void BeAbleToMapTheRight()
    {
        var value = Either<string, int>.Right(2);

        var transformedValue = value.Map(right => right.ToString());

        transformedValue.Match(
            right => right.Should().Be("2"),
            _ => throw new Exception("Should be right, got left")
        );
    }
    
    [Fact]
    public void BeAbleToMapTheLeft()
    {
        var value = Either<string, int>.Left("1");

        var transformedValue = value.MapLeft(int.Parse);

        transformedValue.Match(
            _ => throw new Exception("Should be right, got left"),
            left => left.Should().Be(1)
        );
    }

    [Fact]
    public void BeAbleToBindTheRight()
    {
        var value = Either<string, int>.Right(2);

        var transformedValue = value.Bind(right => Either<string, string>.Right(right.ToString()));

        transformedValue.Match(
            right => right.Should().Be("2"),
            _ => throw new Exception("Should be right, got left")
        );
    }

    [Fact]
    public void BeAbleToBindTheLeft()
    {
        var value = Either<string, int>.Left("1");

        var transformedValue = value.BindLeft(left => Either<int, int>.Left(int.Parse(left)));

        transformedValue.Match(
            _ => throw new Exception("Should be right, got left"),
            left => left.Should().Be(1)
        );
    }
}
