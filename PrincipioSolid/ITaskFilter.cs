public interface ITaskFilter
{
    List<Task> FilterByPriority(List<Task> tasks, string priority);
}
