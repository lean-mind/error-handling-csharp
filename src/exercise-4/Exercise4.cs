namespace LeanMind.ErrorHandling.exercise_4;

public class Exercise4
{
    public static void Main()
    {
        Sum(1, 2, ConsoleOutput);
    }

    private static void Sum(int x, int y, Action<int> printer)
    {
        printer(x + y);
    }
    
    private static void ConsoleOutput(int number)
    {
        Console.WriteLine($"The sum of the numbers is: {number}");
    }
}
