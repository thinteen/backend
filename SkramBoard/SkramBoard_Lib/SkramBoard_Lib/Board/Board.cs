using ScrumBoard.Board;
using ScrumBoard.Column;
using ScrumBoard.Task;

namespace ScrumBoard.Board;

public class Board : IBoard
{
    public Board(string name)
    {
        GUID = Guid.NewGuid().ToString();
        Name = name;
        ColumnList = new List<IColumn>();
    }
    public string GUID { get; }

    public string Name { get; set; }

    private readonly List<IColumn> ColumnList;

    private const int MAX_COLUMN= 10;

    public void AddColumn(IColumn column)
    {
        if (ColumnList.Count >= MAX_COLUMN)
        {
            throw new Exception("Доска заполнена - максимальное количество колонок равно 10");
        }
        if (ColumnList.Contains(column))
        {
            throw new Exception("Такая колонка уже есть");
        }
        ColumnList.Add(column);
    }

    public void DeleteColumn(string GUID)
    {
        for (int i = 0; i < ColumnList.Count; i++)
        {
            if (ColumnList[i].GUID == GUID)
            {
                ColumnList.RemoveAt(i);
                return;
            }
        }
        throw new Exception("Такой колонки не найдено");
    }

    public void RedactColumnName(string GUID, string name)
    {
        for (int i = 0; i < ColumnList.Count; i++)
        {
            if (ColumnList[i].GUID == GUID)
            {
                ColumnList[i].Name = name;
                return;
            }
        }
        throw new Exception("Такой колонки не найдено");
    }

    private int GetNumColumn(string GUID)
    {
        for (int i = 0; i < ColumnList.Count; i++)
        {
            if (ColumnList[i].GUID == GUID)
            {
                return i;
            }
        }
        throw new Exception("Такой колонки не найдено");
    }

    public void AddTask(ITask task, int columnNum = 0)
    {
        if (columnNum < 0 || columnNum >= ColumnList.Count)
        {
            throw new Exception("Такой колонки не найдено");
        }
        ColumnList[columnNum].AddTask(task);
    }

    public void DeleteTask(string GUID)
    {
        for (int i = 0; i < ColumnList.Count; i++)
        {
            if (ColumnList[i].DeleteTask(GUID))
            {
                return;
            }
        }
        throw new Exception("Такой задачи не найдено");
    }

    public void EditTask(string GUID, string name, string description, TaskRating rating)
    {
        for (int i = 0; i < ColumnList.Count; i++)
        {
            if (ColumnList[i].EditTask(GUID, name, description, rating))
            {
                return;
            }
        }
        throw new Exception("Такой задачи не найдено");
    }

    public ITask FindTask(string GUID)
    {
        for (int i = 0; i < ColumnList.Count; i++)
        {
            ITask? result = ColumnList[i].FindTask(GUID);
            if (result != null)
            {
                return result;
            }
        }
        throw new Exception("Такой задачи не найдено");
    }

    public void TransferTask(string column_GUID, string task_GUID)
    {
        ITask task = FindTask(task_GUID);
        DeleteTask(task.GUID);
        AddTask(task, GetNumColumn(column_GUID));
    }
}