using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_CODEBASE_00016197.Data;
using WEB_CODEBASE_00016197.Models_00016197;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_CODEBASE_00016197.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IssueTrackerContext _context;

        public IssuesController(IssueTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Issues 00016197
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.Include(i => i.User).ToListAsync();
        }

        // GET: api/Issues/5 00016197
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.Include(i => i.User).FirstOrDefaultAsync(i => i.IssueId == id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        // POST: api/Issues 00016197
        [HttpPost]
        public async Task<ActionResult<Issue>> CreateIssue(Issue issue)
        {
            // Optional: Validate if the UserId exists
            var userExists = await _context.Users.AnyAsync(u => u.UserId == issue.UserId);
            if (!userExists)
            {
                return BadRequest("User with the specified UserId does not exist.");
            }

            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIssue), new { id = issue.IssueId }, issue);
        }

        // PUT: api/Issues/5 00016197
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(int id, Issue issue)
        {
            if (id != issue.IssueId)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
         
        // DELETE: api/Issues/5 0016197
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.IssueId == id);
        }
    }
}
