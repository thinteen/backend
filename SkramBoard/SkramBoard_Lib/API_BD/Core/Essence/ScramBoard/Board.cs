namespace Core.Essence.ScrumBoard;

public class Board
{
    public Board(string name)
    {
        Name = name;
        Columns = new List<Column>();
    }

    public int BoardId { get; set; }

    public string Name { get; set; }

    public List<Column> Columns { get; set; }
}