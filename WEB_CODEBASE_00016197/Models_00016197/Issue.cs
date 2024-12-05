namespace WEB_CODEBASE_00016197.Models_00016197
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
