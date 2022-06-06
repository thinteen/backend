using Core.Essence.ScrumBoard;

namespace Core.DTO;

public class ColumnDTO
{
    public ColumnDTO(Column column)
    {
        ColumnId = column.ColumnId;
        Name = column.Name;
        Tasks = column.Tasks.Select(task => new TaskDTO(task)).ToList();
    }

    public int ColumnId { get; set; }

    public string Name { get; set; }

    public List<TaskDTO> Tasks { get; set; }
}
