using ScrumBoard.Task;

namespace ScrumBoard.Column;

public class Column : IColumn
{
    public Column(string name)
    {
        GUID = Guid.NewGuid().ToString();
        Name = name;
        TasksList = new List<ITask>();
    }

    public string GUID { get; }

    public string Name { get; set; }

    private readonly List<ITask> TasksList;

    public void AddTask(ITask task)
    {
        if (TasksList.Contains(task))
        {
            throw new Exception("Такая задача существует");
        }
        TasksList.Add(task);
    }

    public bool DeleteTask(string GUID)
    {
        for (int i = 0; i < TasksList.Count; i++)
        {
            if (TasksList[i].GUID == GUID)
            {
                TasksList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public bool EditTask(string GUID, string name, string description, TaskRating rating)
    {
        for (int i = 0; i < TasksList.Count; i++)
        {
            if (TasksList[i].GUID == GUID)
            {
                TasksList[i].Name = name;
                TasksList[i].Description = description;
                TasksList[i].Rating = rating;
                return true;
            }
        }
        return false;
    }

    public ITask? FindTask(string GUID)
    {
        for (int i = 0; i < TasksList.Count; i++)
        {
            if (TasksList[i].GUID == GUID)
            {
                return TasksList[i];
            }
        }
        return null;
    }

    public void DeleteAllTask()
    {
        TasksList.Clear();
    }
}