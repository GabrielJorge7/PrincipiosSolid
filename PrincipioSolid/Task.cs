public class Task : ICompletable, IPrintable
{
    public string Title { get; }
    public string Priority { get; }
    private bool done;

    public Task(string title, string priority)
    {
        Title = title;
        Priority = priority;
        done = false;
    }

    public void MarkAsDone()
    {
        done = true;
    }

    public bool IsDone()
    {
        return done;
    }

    public void Print()
    {
        Console.WriteLine($"[{(done ? "X" : " ")}] {Title} (Prioridade: {Priority})");
    }
}
