using ScrumBoard.Column;
using ScrumBoard.Task;

namespace ScrumBoard.Board;

public interface IBoard
{
    public string GUID { get; }

    public string Name { get; set; }

    public void AddColumn(IColumn column);

    public void DeleteColumn(string GUID);

    public void RedactColumnName(string GUID, string name);

    public void AddTask(ITask task, int columnNum = 0);

    public void DeleteTask(string GUID);

    public void EditTask(string GUID, string name, string description, TaskRating rating);

    public ITask FindTask(string GUID);

    public void TransferTask(string column_GUID, string task_GUID);
}