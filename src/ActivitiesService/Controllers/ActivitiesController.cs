using ActivitiesService.Data;
using ActivitiesService.DTOs;
using ActivitiesService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesService.Controllers;

[ApiController]
[Route("api/activities")]
public class ActivitiesController : ControllerBase
{
    private readonly ActivityDBContext _context;
    private readonly IMapper _mapper;

    public ActivitiesController(ActivityDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<List<ActivityDto>>> GetAllActivities()
    {
        var activities = await _context.Activities
        .Include(x => x.Task)
        .OrderBy(x => x.Task.Name)
        .ToListAsync();

        return _mapper.Map<List<ActivityDto>>(activities);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetActivityById(Guid id)
    {
        var activity = await _context.Activities
        .Include(x => x.Task)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (activity == null)
        {
            return NotFound();
        }

        return _mapper.Map<ActivityDto>(activity);
    }
    
    [HttpPost]
    public async Task<ActionResult<ActivityDto>> CreateActivity(CreateActivityDto activityDto)
    {
        var activity = _mapper.Map<Activity>(activityDto);

        activity.Author = "test";

        _context.Activities.Add(activity);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result)
        {
            return BadRequest("Could not save changes to the database");
        }

        return CreatedAtAction(nameof(GetActivityById), new {activity.Id }, _mapper.Map<ActivityDto>(activity));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateActivity(Guid id, UpdateActivityDto updateActivityDto)
    {
        var activity = await _context.Activities.Include(x => x.Task).FirstOrDefaultAsync(x => x.Id == id);

        if (activity == null)
        {
            return NotFound();
        }

        activity.Task.Name = updateActivityDto.Name ?? activity.Task.Name;
        activity.Task.Description = updateActivityDto.Description ?? activity.Task.Description;
        activity.Task.PredictedTime = updateActivityDto.PredictedTime ?? activity.Task.PredictedTime;
        activity.Task.Category = updateActivityDto.Category ?? activity.Task.Category;
        activity.Task.Experience = updateActivityDto.Experience ?? activity.Task.Experience;

        var result = await _context.SaveChangesAsync() > 0;

        if (!result)
        {
            return BadRequest("Could not save changes");
        }

        return Ok(); 

    }

    [HttpDelete("{id}")]    
    public async Task<ActionResult> DeleteActivity(Guid id)
    {
        var activity = await _context.Activities.FindAsync(id);

        if (activity == null)
        {
            return NotFound();
        }

        _context.Activities.Remove(activity);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result)
        {
            return BadRequest("Could not update DB");
        }

        return Ok();
    }

}