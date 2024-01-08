using Microsoft.AspNetCore.Authorization;
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
    public class StoryController : ControllerBase
    {
        private readonly VisionDbContext _context;

        public StoryController(VisionDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllStories")]
        public async Task<ActionResult<IEnumerable<StoryDTO>>> GetAllStories()
        {
            var stories = await _context.Stories.ToListAsync();
            var storyDTOs = stories.Select(story => new StoryDTO
            {
                PK = story.PK,
                LaneId = story.LanePK,
                Title = story.Title,
                Description = story.Description,
                Status = story.Status,
                CreationDate = story.CreationDate,
                ArchiveDate = story.ArchiveDate
            }).ToList();

            return Ok(storyDTOs);
        }

        [HttpGet("{id}", Name = "GetStoryById")]
        public async Task<ActionResult<StoryDTO>> GetStory(Guid id)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            var storyDTO = new StoryDTO
            {
                PK = story.PK,
                LaneId = story.LanePK,
                Title = story.Title,
                Description = story.Description,
                Status = story.Status,
                CreationDate = story.CreationDate,
                ArchiveDate = story.ArchiveDate
            };

            return storyDTO;
        }

        [HttpPost(Name = "CreateStory")]
        public async Task<ActionResult<StoryDTO>> CreateStory(CreateStoryDTO storyDTO)
        {
            var story = new Story
            {
                Title = storyDTO.Title,
                Description = storyDTO.Description,
                Status = storyDTO.Status,
                CreationDate = DateTime.Now,
                LanePK = storyDTO.LaneID
            };

            _context.Stories.Add(story);
            await _context.SaveChangesAsync();

            return await GetStory(story.PK);
        }

        [HttpPut("{id}", Name = "UpdateStory")]
        public async Task<ActionResult> UpdateStory(Guid id, StoryDTO storyDTO)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            story.Title = storyDTO.Title;
            story.Description = storyDTO.Description;
            story.Status = storyDTO.Status;
            story.CreationDate = storyDTO.CreationDate;
            story.ArchiveDate = storyDTO.ArchiveDate;

            _context.Stories.Update(story);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStory")]
        public async Task<ActionResult> DeleteStory(Guid id)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
