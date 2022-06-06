using Core.DTO;
using Core.Essence.ScrumBoard;
using Task = Core.Essence.ScrumBoard.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.Interface;

namespace Infrastructure.Data;

public class ScrumBoardRepository : IScrumBoardRepository
{
    private readonly ScrumBoardRelation _db;

    public ScrumBoardRepository(IConfiguration configuration)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ScrumBoardRelation>();

        DbContextOptions<ScrumBoardRelation>? options = optionsBuilder.UseMySql(
                configuration.GetConnectionString("Standard"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Standard"))
            ).Options;

        _db = new ScrumBoardRelation(options);
    }

    public IEnumerable<BoardDTO> GetListBoard()
    {
        return _db.Boards.Include(c => c.Columns)
            .ThenInclude(t => t.Tasks)
            .Select(board => new BoardDTO(board));
    }

    public void CreateBoard(CreateBoardDTO param)
    {
        Board board = new(param.Name);

        _db.Boards.Add(board);
        _db.SaveChanges();
    }

    public BoardDTO GetBoard(int boardId)
    {
        Board? board = _db.Boards.Include(c => c.Columns)
            .ThenInclude(t => t.Tasks)
            .Where(b => b.BoardId == boardId)
            .FirstOrDefault();

        if (board == null)
        {
            throw new Exception("Такой доски не найдено");
        }

        return new BoardDTO(board);
    }

    public void DeleteBoard(int boardId)
    {
        Board? board = _db.Boards.Find(boardId);
        if (board != null)
        {
            _db.Boards.Remove(board);
            _db.SaveChanges();
        }
        else
        {
            throw new Exception("Такой доски не найдено");
        }
    }

    public void CreateColumn(int boardId, CreateColumnDTO param)
    {
        Board? board = _db.Boards.Include(c => c.Columns)
            .Where(b => b.BoardId == boardId)
            .FirstOrDefault();

        if (board != null)
        {
            if (board.Columns.Count() < 10)
            {
                Column column = new(param.Name, boardId);

                _db.Columns.Add(column);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Количество колонок не может быть больше 10");
            }
        }
        else
        {
            throw new Exception("Такой доски не найдено");
        }
    }

    public void EditColumn(int columnId, EditColumnDTO param)
    {
        Column? column = _db.Columns.Find(columnId);
        if (column != null)
        {
            column.Name = param.Name;
            _db.SaveChanges();
        }
        else
        {
            throw new Exception("Такой колонки не найдено");
        }
    }

    public void DeleteColumn(int columnId)
    {
        Column? column = _db.Columns.Find(columnId);
        if (column != null)
        {
            _db.Columns.Remove(column);
            _db.SaveChanges();
        }
        else
        {
            throw new Exception("Такой колонки не найдено");
        }
    }

    public void CreateTask(int boardId, CreateTaskDTO param)
    {
        if ((param.Rating < (int)TaskRating.Low) || (param.Rating > (int)TaskRating.High))
        {
            throw new Exception();
        }

        Board? board = _db.Boards.Include(c => c.Columns)
            .Where(b => b.BoardId == boardId)
            .FirstOrDefault();

        if (board != null)
        {
            Column? column = board.Columns.FirstOrDefault();
            if (column != null)
            {
                Task task = new(param.Name, param.Description, param.Rating, column.ColumnId);

                _db.Tasks.Add(task);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Такой колонки не найдено");
            }
        }
        else
        {
            throw new Exception("Такой доски не найдено");
        }
    }

    public void EditTask(int taskId, EditTaskDTO param)
    {
        if ((param.Rating < (int)TaskRating.Low) || (param.Rating > (int)TaskRating.High))
        {
            throw new Exception();
        }

        Task? task = _db.Tasks.Find(taskId);
        if (task != null)
        {
            task.Name = param.Name;
            task.Description = param.Description;
            task.Rating = param.Rating;
            _db.SaveChanges();
        }
        else
        {
            throw new Exception("Такого задания не найдено");
        }
    }

    public void MoveTask(int taskId, int columnId)
    {
        Task? task = _db.Tasks.Find(taskId);

        if (task == null)
        {
            throw new Exception();
        }

        Column? column = _db.Columns.Find(columnId);

        if (column == null)
        {
            throw new Exception("Такой колонки не найдено");
        }

        task.ColumnId = columnId;
        _db.SaveChanges();
    }

    public void DeleteTask(int taskId)
    {
        Task? task = _db.Tasks.Find(taskId);
        if (task != null)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
        else
        {
            throw new Exception("Такого задания не найдено");
        }
    }
}