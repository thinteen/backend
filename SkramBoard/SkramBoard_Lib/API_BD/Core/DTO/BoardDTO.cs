using Core.Essence.ScrumBoard;

namespace Core.DTO;
public class BoardDTO
{
    public BoardDTO(Board board)
    {
        BoardId = board.BoardId;
        Name = board.Name;
        Columns = board.Columns.Select(column => new ColumnDTO(column)).ToList();
    }

    public int BoardId { get; set; }

    public string Name { get; set; }

    public List<ColumnDTO> Columns { get; set; }
}