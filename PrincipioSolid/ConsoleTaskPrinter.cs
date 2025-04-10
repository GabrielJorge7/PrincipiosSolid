using System.Collections.Generic;

public class ConsoleTaskPrinter : ITaskPrinter
{
    public void PrintTasks(List<Task> tasks)
    {
        foreach (var task in tasks)
        {
            task.Print();
        }
    }
}
