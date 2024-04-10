using FluentAssertions;
using Xunit;

namespace LeanMind.ErrorHandling.exercise_4;

public class Exercise4Tests
{
    [Fact]
    void Ex1Filtering()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var greaterThan5Numbers = numbers.Where(GreaterThan5).ToArray();
        var oddNumbers = numbers.Where(IsOddNumber).ToArray();
        var evenNumbers = numbers.Where(IsEvenNumber).ToArray();

        greaterThan5Numbers.Should().BeEquivalentTo(new[] { 6, 7, 8, 9, 10 });
        oddNumbers.Should().BeEquivalentTo(new[] { 1, 3, 5, 7, 9 });
        evenNumbers.Should().BeEquivalentTo(new[] { 2, 4, 6, 8, 10 });
        
        return;
        bool GreaterThan5(int numberToCompare) => numberToCompare > 5;
        bool IsOddNumber(int numberToCompare) => numberToCompare % 2 != 0;
        bool IsEvenNumber(int numberToCompare) => numberToCompare % 2 == 0;
    }

    [Fact]
    public void Currying()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var greaterThan5Numbers = numbers.Where(IsGreaterThan(5)).ToArray();
        var divisibleBy3Numbers = numbers.Where(IsDivisibleBy(3)).ToArray();
        
        greaterThan5Numbers.Should().BeEquivalentTo(new[] { 6, 7, 8, 9, 10 });
        divisibleBy3Numbers.Should().BeEquivalentTo(new[] { 3, 6, 9 });
        
        return;

        Func<int, bool> IsGreaterThan(int aNumber)
        {
            return anotherNumber => anotherNumber > aNumber;
        }

        Func<int, bool> IsDivisibleBy(int numberToBeDivisibleBy)
        {
            return number => number % numberToBeDivisibleBy == 0;
        }
    }
}