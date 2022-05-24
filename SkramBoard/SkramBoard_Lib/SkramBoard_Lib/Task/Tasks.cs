namespace ScrumBoard.Task;

public class Task : ITask
{
    public Task(string name, string description, TaskRating rating)
    {
        GUID = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        Rating = rating;
    }

    public string GUID { get; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TaskRating Rating { get; set; }
}