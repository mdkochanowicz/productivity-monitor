using ActivitiesService.Data;
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
    
    
}