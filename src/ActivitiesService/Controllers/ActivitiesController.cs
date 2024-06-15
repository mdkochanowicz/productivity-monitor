using ActivitiesService.Data;
using ActivitiesService.DTOs;
using ActivitiesService.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesService.Controllers;

[ApiController]
[Route("api/activities")]
public class ActivitiesController : ControllerBase
{
    private readonly ActivityDBContext _context;
    private readonly IMapper _mapper;
    private IPublishEndpoint _publishEndpoint;

    public ActivitiesController(ActivityDBContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }
    [HttpGet]
    public async Task<ActionResult<List<ActivityDto>>> GetAllActivities(string date)
    {
        var query = _context.Activities.OrderBy(x=>x.Task.Name).AsQueryable();

        if(!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => DateTime.Compare((DateTime)x.UpdatedAt, DateTime.Parse(date).ToUniversalTime()) > 0);
            //tam wyzej cos pomieszane
            //powinny byc query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<ActivityDto>(_mapper.ConfigurationProvider).ToListAsync();
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

        var newActivity = _mapper.Map<ActivityDto>(activity);

        await _publishEndpoint.Publish(_mapper.Map<ActivityCreated>(newActivity));

        if (!result)
        {
            return BadRequest("Could not save changes to the database");
        }

        return CreatedAtAction(nameof(GetActivityById), new {activity.Id }, newActivity);
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