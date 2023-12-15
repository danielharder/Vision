using Microsoft.AspNetCore.Mvc;
using Vision.Server.Models;
using Vision.Server.DTO;
using System.Linq;

namespace Vision.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskBoardController : ControllerBase
    {
        private readonly VisionDbContext _context;
        public TaskBoardController(VisionDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "TaskBoard")]
        public ActionResult<IEnumerable<BoardDTO>> Get()
        {
            var boards = _context.Boards.ToList();
            var BoardDTOS = boards.Select(board => new BoardDTO
                PK = board.PK,
                Name = board.Name,
                Description = board.Description,
                BoardMembers = _context.BoardMembers
                                    .Where(bm => bm.BoardId == board.Id)
                                    .Select(bm => bm.UserId)
                                    .ToList();
        }).ToList();
        return Ok(BoardDTOS);
    }
}
