using ScrumBoard.Column;

namespace ScrumBoardAPI.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(IColumn column)
    {
        id = column.id;
        Name = column.Name;
    }

    public string id { get; set; }

    public string Name { get; set; }

    public IEnumerable<TaskDTO> Tasks { get; set; }
}