using Task = Core.Essence.ScrumBoard.Task;

namespace Core.DTO;

public class TaskDTO
{
    public TaskDTO(Task task)
    {
        TaskId = task.TaskId;
        Name = task.Name;
        Description = task.Description;
        Rating = task.Rating.ToString();
    }

    public int TaskId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Rating { get; set; }
}
