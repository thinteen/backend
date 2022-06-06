using ScrumBoard.Board;

namespace ScrumBoardAPI.DTO;

public class BoardDTO
{
    public BoardDTO(IBoard board)
    {
        id = board.id;
        Name = board.Name;
    }

    public string id { get; set; }

    public string Name { get; set; }

    public IEnumerable<ColumnsDTO> Columns { get; set; }
}