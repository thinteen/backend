using ScrumBoard.Task;

namespace ScrumBoardAPI.DTO;

public class TaskDTO
{
    public TaskDTO(ITask task)
    {
        id = task.id;
        Name = task.Name;
        Description = task.Description;
        Rating = task.Rating.ToString();
    }

    public string id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Rating { get; set; }
}