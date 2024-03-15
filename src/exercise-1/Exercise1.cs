namespace LeanMind.ErrorHandling.exercise_1;


public interface Value
{
    object GetValue();
}

public class StringValue : Value
{
    private readonly string value;

    public StringValue(string value)
    {
        this.value = value;
    }

    public object GetValue()
    {
        return value;
    }
}

public class NumberValue : Value
{
    private readonly int value;

    public NumberValue(int value)
    {
        this.value = value;
    }

    public object GetValue()
    {
        return value;
    }
}

public class ValueList<T> where T : Value
{
    private T[] values;

    public ValueList(T[] values)
    {
        this.values = values;
    }
    
    public void Add(T value)
    {
        values = values.Append(value).ToArray();
    }

    public ValueList<T> Filter(Func<T, bool>predicate)
    {
        return new ValueList<T>(values.Where(predicate).ToArray());
    }

    public override string ToString()
    {
        return String.Join(", ", values.Select(value => value.GetValue()));
    }
}
