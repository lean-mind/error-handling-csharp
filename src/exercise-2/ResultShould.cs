using FluentAssertions;
using LeanMind.ErrorHandling.domain;
using Xunit;

namespace LeanMind.ErrorHandling.exercise_2;

public class ResultShould
{
    [Fact]
    public void BuildASuccessResult()
    {
        var result = Result<string>.Success("irrelevant");

        result.IsSuccess().Should().BeTrue();
        result.value.Should().Be("irrelevant");
        result.error.Should().BeNull();
    }
    
    [Fact]
    public void BuildAnErrorResult()
    {
        var result = Result<string>.WithError(Error.UserAlreadyExists);

        result.IsSuccess().Should().BeFalse();
        result.value.Should().BeNull();
        result.error.Should().Be(Error.UserAlreadyExists);
    }
}