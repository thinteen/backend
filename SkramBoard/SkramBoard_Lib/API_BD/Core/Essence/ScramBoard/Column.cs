namespace Core.Essence.ScrumBoard;

public class Column
{
    public Column(string name, int boardId)
    {
        Name = name;
        BoardId = boardId;
        Tasks = new List<Task>();
    }

    public int ColumnId { get; set; }

    public string Name { get; set; }

    public int BoardId { get; set; }

    public List<Task> Tasks { get; set; }

    public Board Board { get; set; }
}