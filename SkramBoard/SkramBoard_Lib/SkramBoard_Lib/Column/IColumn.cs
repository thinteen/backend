using ScrumBoard.Task;

namespace ScrumBoard.Column;

public interface IColumn
{
    public string GUID { get; }

    public string Name { get; set; }

    public void AddTask(ITask task);

    public bool DeleteTask(string GUID);

    public bool EditTask(string GUID, string name, string description, TaskRating rating);

    public ITask? FindTask(string GUID);

    public void DeleteAllTask();
}