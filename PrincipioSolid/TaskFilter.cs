using System.Collections.Generic;
using System.Linq;

public class TaskFilter : ITaskFilter
{
    public List<Task> FilterByPriority(List<Task> tasks, string priority)
    {
        return tasks.Where(t => t.Priority.ToLower() == priority.ToLower()).ToList();
    }
}
