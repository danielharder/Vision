using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.Server.DTO.CreateDTOs;
using Vision.Server.Models;

namespace Vision.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LaneController : ControllerBase
    {
        private readonly VisionDbContext _context;
        public LaneController(VisionDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllLanes")]
        public async Task<ActionResult<IEnumerable<LaneDTO>>> GetAllLanes()
        {
            var lanes = await _context.Lanes.ToListAsync();
            var laneDTOs = lanes.Select(lane => new LaneDTO
            {
                PK = lane.PK,
                BoardId = lane.BoardPK,
                Name = lane.Name
            }).ToList();

            return Ok(laneDTOs);
        }

        [HttpGet("{id}", Name = "GetLaneById")]
        public async Task<ActionResult<LaneDTO>> GetLane(Guid id)
        {
            var lane = await _context.Lanes.FindAsync(id);
            if (lane == null)
            {
                return NotFound();
            }

            var laneDTO = new LaneDTO
            {
                PK = lane.PK,
                BoardId = lane.BoardPK,
                Name = lane.Name
            };

            return laneDTO;
        }

        [HttpPost(Name = "CreateLane")]
        public async Task<ActionResult<LaneDTO>> CreateLane(CreateLaneDTO laneDTO)
        {
            var lane = new Lane
            {
                Name = laneDTO.Name,
                BoardPK = laneDTO.BoardID
            };

            _context.Lanes.Add(lane);
            await _context.SaveChangesAsync();

            return await GetLane(lane.PK);
        }

        [HttpPut("{id}", Name = "UpdateLane")]
        public async Task<ActionResult> UpdateLane(Guid id, CreateLaneDTO laneDTO)
        {
            var lane = await _context.Lanes.FindAsync(id);
            if (lane == null)
            {
                return NotFound();
            }

            lane.Name = laneDTO.Name;

            _context.Lanes.Update(lane);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteLane")]
        public async Task<ActionResult> DeleteLane(Guid id)
        {
            var lane = await _context.Lanes.FindAsync(id);
            if (lane == null)
            {
                return NotFound();
            }

            _context.Lanes.Remove(lane);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}
