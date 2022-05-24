namespace ScrumBoard.Task;

public enum TaskRating
{
    High,
    Medium,
    Low
}

public interface ITask
{
    public string GUID { get; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TaskRating Rating { get; set; }
}
