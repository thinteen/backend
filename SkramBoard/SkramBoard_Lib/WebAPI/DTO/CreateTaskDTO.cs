namespace ScrumBoardAPI.DTO;

public class CreateTaskDTO
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Rating { get; set; }
}