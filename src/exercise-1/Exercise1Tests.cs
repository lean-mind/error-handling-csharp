using FluentAssertions;
using Xunit;

namespace LeanMind.ErrorHandling.exercise_1;

public class Exercise1Tests
{
    [Fact]
    public void Test1()
    {
        var numberValue1 = new NumberValue(1);
        var numberValue2 = new NumberValue(2);

        var stringValue1 = new StringValue("hello");
        var stringValue2 = new StringValue("world");

        var values = new ValueList<Value>(new Value[] { numberValue1, numberValue2, stringValue1, stringValue2 });
        
        values.Add(new StringValue("foo"));

        var numberValues = values.Filter(value => value is NumberValue);
        var stringValues = values.Filter(value => value is StringValue);

        values.ToString().Should().Be("1, 2, hello, world, foo");
        numberValues.ToString().Should().Be("1, 2");
        stringValues.ToString().Should().Be("hello, world, foo");
    }
}