public enum HearthState
{
    Life,
    Middle,
    Death
}

public static class HearthStateExtensions
{
    public static HearthState Next(this HearthState current)
    {
        int next = ((int)current + 1) % System.Enum.GetValues(typeof(HearthState)).Length;
        return (HearthState)next;
    }
}