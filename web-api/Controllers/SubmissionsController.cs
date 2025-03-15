using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;


[Route("api/[controller]")]
[ApiController]
public class SubmissionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SubmissionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubmission([FromBody] object formData)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        var submission = new Submission
        {
            Data = formData.ToString()
        };
#pragma warning restore CS8601 // Possible null reference assignment.
        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSubmission), new { id = submission.Id }, submission);
    }

    // GET: api/submissions
    [HttpGet]
    public async Task<IActionResult> GetSubmissions()
    {
        var submissions = await _context.Submissions.ToListAsync();
        return Ok(submissions);
    }

    // GET: api/submissions/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubmission(int id)
    {
        var submission = await _context.Submissions.FindAsync(id);
        if (submission == null) return NotFound();
        return Ok(submission);
    }

    // GET: api/submissions/search?field={field}&value={value}
    [HttpGet("search")]
    public async Task<IActionResult> SearchSubmissions(string field, string value)
    {
        var submissions = await _context.Submissions.ToListAsync();
        var filtered = submissions
            .Select(s => new { s.Id, Data = JObject.Parse(s.Data) })
            .Where(s => s.Data[field]?.ToString().Contains(value, StringComparison.OrdinalIgnoreCase) == true)
            .Select(s => new Submission { Id = s.Id, Data = s.Data.ToString() });
        return Ok(filtered);
    }
}