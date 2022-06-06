namespace Core.Essence.ScrumBoard;

public enum TaskRating
{
    Low,
    Medium,
    High
}

public class Task
{
    public Task(string name, string description, int rating, int columnId)
    {
        Name = name;
        Description = description;
        Rating = rating;
        ColumnId = columnId;
    }

    public int TaskId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Rating { get; set; }

    public int ColumnId { get; set; }

    public Column Column { get; set; }
}