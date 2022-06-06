using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ScrumBoardAPI.DTO;
using ScrumBoard.Board;
using ScrumBoard.Column;
using ScrumBoard.Task;
using Task = ScrumBoard.Task.Task;

namespace ScrumBoardAPI.Controllers;

[Route("API/boards")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    public Controller(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    private List<IBoard> GetListBoard()
    {
        _memoryCache.TryGetValue("boards", out List<IBoard> boards);

        if (boards == null)
        {
            throw new Exception("Досок нет");
        }
        return boards;
    }

    private int GetIndexBoard(string boardID)
    {
        List<IBoard> boards = GetListBoard();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].id == boardID)
            {
                return i;
            }
        }
        throw new Exception("Такой доски не найдено");
    }

    private static TaskRating GetTaskRating(int priority)
    {
        if (priority == 0)
            priority = (int)TaskRating.Low;
        if (priority == 1)
            priority = (int)TaskRating.Medium;
        if (priority == 2)
            priority = (int)TaskRating.High;

        return (TaskRating)priority;
    }

    [HttpGet]
    public IActionResult GetListBoards()
    {
        IEnumerable<BoardDTO> boards;
        try
        {
            return Ok(GetListBoard().Select(board => new BoardDTO(board)));
        }
        catch
        {
            boards = Enumerable.Empty<BoardDTO>();
        }
        return BadRequest();
    }

    [HttpPost]
    public IActionResult CreateBoard([FromBody] CreateBoardDTO param)
    {
        try
        {
            List<IBoard> boards;
            try
            {
                boards = GetListBoard();
            }
            catch (Exception)
            {
                boards = new List<IBoard>();
            }

            boards.Add(new Board(param.Name));

            _memoryCache.Set("boards", boards);
            return Ok();
        }
        catch
        {
            return BadRequest();
        } 
    }

    [HttpGet("{boardID}")]
    public IActionResult FindBoardByID(string boardID)
    {
        BoardDTO board;
        try
        {
            return Ok(new BoardDTO(GetListBoard()[GetIndexBoard(boardID)]));
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpDelete("{boardID}")]
    public IActionResult DeleteBoard(string boardID)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            for (int i = 0; i < boards.Count; i++)
            {
                if (boards[i].id == boardID)
                {
                    boards.RemoveAt(i);
                    _memoryCache.Set("boards", boards);
                    return Ok();
                }
            }
            return NotFound();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("{boardID}/column")]
    public IActionResult CreateColumn(string boardID, [FromBody] CreateColumnDTO param)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].AddColumn(new Column(param.Name));

            _memoryCache.Set("boards", boards);
            return Ok();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPut("{boardID}/column")]
    public IActionResult EditColumn(string boardID, [FromBody] EditColumnDTO param)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].RedactColumnName(param.id, param.Name);

            _memoryCache.Set("boards", boards);

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
        
    }

    [HttpDelete("{boardID}/column/{columnID}")]
    public IActionResult DeleteColumn(string boardID, string columnID)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].DeleteColumn(columnID);

            _memoryCache.Set("boards", boards);

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost("{boardID}/task")]
    public IActionResult CreateTask(string boardID, [FromBody] CreateTaskDTO param)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].AddTask(
                new Task(param.Name, param.Description, GetTaskRating(param.Rating)));

            _memoryCache.Set("boards", boards);

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("{boardID}/task")]
    public IActionResult EditTask(string boardID, [FromBody] EditTaskDTO param)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].EditTask(
                param.id, param.Name, param.Description, GetTaskRating(param.Rating)
            );

            _memoryCache.Set("boards", boards);

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("{boardID}/task/{taskID}")]
    public IActionResult MoveTask(string boardID, string taskID, [FromBody] MoveTaskDTO param)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].MoveTask(param.columnid, taskID);

            _memoryCache.Set("boards", boards);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardID}/task/{taskID}")]
    public IActionResult DeleteTask(string boardID, string taskID)
    {
        try
        {
            List<IBoard> boards = GetListBoard();

            boards[GetIndexBoard(boardID)].DeleteTask(taskID);

            _memoryCache.Set("boards", boards);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    } 
}