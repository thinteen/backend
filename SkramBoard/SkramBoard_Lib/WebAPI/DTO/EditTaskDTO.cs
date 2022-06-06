namespace ScrumBoardAPI.DTO;

public class EditTaskDTO
{
    public string? id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Rating { get; set; }
}