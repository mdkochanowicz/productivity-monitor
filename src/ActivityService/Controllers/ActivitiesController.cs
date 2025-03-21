using ActivityService.Data;
using ActivityService.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.Controllers;

[ApiController]
[Route("api/activities")]
public class ActivitiesController : ControllerBase
{
    private readonly ActivityDbContext _context;
    private readonly IMapper _mapper;
    public ActivitiesController(ActivityDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ActivityDto>>>GetAllActivities()
    {
        var activities = await _context.Activities
        .Include(x => x.Task)
        .OrderBy(x => x.Task.Name)
        .ToListAsync();

        return _mapper.Map<List<ActivityDto>>(activities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetActivity(Guid id)
    {
        var activity = await _context.Activities
        .Include(x => x.Task)
        .FirstOrDefaultAsync(x => x.Id == id);

        if(activity == null)
        {
            return NotFound();
        }

        return _mapper.Map<ActivityDto>(activity);
    }
}