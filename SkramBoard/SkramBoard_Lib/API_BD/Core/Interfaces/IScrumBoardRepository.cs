using Core.DTO;

namespace Core.Interface;

public interface IScrumBoardRepository
{
    public IEnumerable<BoardDTO> GetListBoard();

    public BoardDTO GetBoard(int boardId);

    public void CreateBoard(CreateBoardDTO param);

    public void DeleteBoard(int boardId);

    public void CreateColumn(int boardId, CreateColumnDTO param);

    public void EditColumn(int columnId, EditColumnDTO param);

    public void DeleteColumn(int columnId);

    public void CreateTask(int boardId, CreateTaskDTO param);

    public void EditTask(int taskId, EditTaskDTO param);

    public void DeleteTask(int taskId);

    public void MoveTask(int taskId, int columnId);
}