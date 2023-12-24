using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.Server.DTO;
using Vision.Server.Models;

[ApiController]
[Route("[controller]")]
public class TaskBoardController : ControllerBase
{
    private readonly VisionDbContext _context;

    public TaskBoardController(VisionDbContext context)
    {
        _context = context;
    }

    // Get all boards
    [HttpGet(Name = "GetTaskBoards")]
    public async Task<ActionResult<IEnumerable<BoardDTO>>> Get()
    {
        var boards = await _context.Boards.ToListAsync();
        var boardDTOs = boards.Select(board => new BoardDTO
        {
            PK = board.PK,
            Name = board.Name,
            Description = board.Description,
            BoardMembers = _context.BoardMembers
                                  .Where(bm => bm.BoardPK == board.PK)
                                  .Select(bm => new BoardMemberDTO
                                  {
                                      UserPK = bm.UserPK,
                                      Role = bm.Role
                                  }).ToList()
        }).ToList();

        return Ok(boardDTOs);
    }



    // Get board by ID
    [HttpGet("{id}", Name = "GetTaskBoardById")]
    public async Task<ActionResult<BoardDTO>> Get(Guid id)
    {
        var board = await _context.Boards.FindAsync(id);
        if (board == null)
        {
            return NotFound();
        }

        var boardDTO = new BoardDTO
        {
            PK = board.PK,
            Name = board.Name,
            Description = board.Description
        };

        return boardDTO;
    }

    // Create Board
    [HttpPost(Name = "CreateTaskBoard")]
    public async Task<ActionResult<BoardDTO>> Post(BoardDTO boardDTO)
    {
        var board = new Board
        {
            Name = boardDTO.Name,
            Description = boardDTO.Description
        };

        _context.Boards.Add(board);
        await _context.SaveChangesAsync();

        boardDTO.PK = board.PK;

        return CreatedAtAction(nameof(Get), new { id = board.PK }, boardDTO);
    }

    // Update Board
    [HttpPut("{id}", Name = "UpdateTaskBoard")]
    public async Task<ActionResult<BoardDTO>> Put(Guid id, BoardDTO boardDTO)
    {
        var board = await _context.Boards.FindAsync(id);
        if (board == null)
        {
            return NotFound();
        }

        board.Name = boardDTO.Name;
        board.Description = boardDTO.Description;

        _context.Boards.Update(board);
        await _context.SaveChangesAsync();

        return Ok(boardDTO);
    }

    // Delete Board
    [HttpDelete("{id}", Name = "DeleteTaskBoard")]
    public async Task<ActionResult> DeleteTaskBoard(Guid id)
    {
        var board = await _context.Boards.FindAsync(id);
        if (board == null)
        {
            return NotFound();
        }

        _context.Boards.Remove(board);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
