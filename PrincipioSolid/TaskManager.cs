public class TaskManager : ITaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public List<Task> GetAllTasks()
    {
        return tasks;
    }
}
