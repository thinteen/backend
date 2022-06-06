using Core.DTO;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ScrumBoardAPI.Controllers;

[Route("API/boards")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly IScrumBoardRepository _repository;

    public BoardsController(IScrumBoardRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetListBoards()
    {
        return Ok(_repository.GetListBoard());
    }

    [HttpPost]
    public IActionResult CreateBoard([FromBody] CreateBoardDTO param)
    {
        try
        {
            _repository.CreateBoard(param);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpGet("{boardId}")]
    public IActionResult GetBoardByGUID(int boardId)
    {
        BoardDTO board;
        try
        {
            board = _repository.GetBoard(boardId);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        return Ok(board);
    }

    [HttpDelete("{boardId}")]
    public IActionResult DeleteBoard(int boardId)
    {
        try
        {
            _repository.DeleteBoard(boardId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPost("{boardId}/column")]
    public IActionResult CreateColumn(int boardId, [FromBody] CreateColumnDTO param)
    {
        try
        {
            _repository.CreateColumn(boardId, param);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        return Ok();
    }

    [HttpPut("column/{columnId}")]
    public IActionResult EditColumn(int columnId, [FromBody] EditColumnDTO param)
    {
        try
        {
            _repository.EditColumn(columnId, param);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpDelete("column/{columnId}")]
    public IActionResult DeleteColumn(int columnId)
    {
        try
        {
            _repository.DeleteColumn(columnId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPost("{boardId}/task")]
    public IActionResult CreateTask(int boardId, [FromBody] CreateTaskDTO param)
    {
        try
        {
            _repository.CreateTask(boardId, param);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPut("task/{taskId}")]
    public IActionResult EditTask(int taskId, [FromBody] EditTaskDTO param)
    {
        try
        {
            _repository.EditTask(taskId, param);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpDelete("task/{taskId}")]
    public IActionResult DeleteTask(int taskId)
    {
        try
        {
            _repository.DeleteTask(taskId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPut("column/{columnId}/task/{taskId}")]
    public IActionResult MoveTask(int taskId, int columnId)
    {
        try
        {
            _repository.MoveTask(taskId, columnId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }
}