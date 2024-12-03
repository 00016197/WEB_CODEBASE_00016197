using Microsoft.EntityFrameworkCore;
using WEB_CODEBASE_00016197.Models_00016197;


namespace WEB_CODEBASE_00016197.Data
{

    public class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }

    }
}
