using Microsoft.AspNetCore.Mvc;
using Vision.Server.Models;
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
            {
                PK = board.PK,
                Name = board.Name,
                Description = board.Description
                //BoardMembers = _context.BoardMembers
                //                    .Where(bm => bm.UserId == board.Id)
                //                    .Select(bm => bm.UserId).ToString()
                //                    .ToList()
            }).ToList();

            return Ok(BoardDTOS);
        }
        [HttpPost(Name = "TaskBoard")]
        public ActionResult<BoardDTO> Post(BoardDTO boardDTO)
        {
            // Convert DTO to Entity model
            var board = new Board
            {
                Name = boardDTO.Name,
                Description = boardDTO.Description
            };

            // Add board to the database context and save changes
            _context.Boards.Add(board);
            _context.SaveChanges();

            // Set the primary key (PK) from the saved entity to the DTO
            boardDTO.PK = board.PK;

            // Return the created board data
            return CreatedAtAction(nameof(Get), new { id = board.PK }, boardDTO);
        }


    }
}
