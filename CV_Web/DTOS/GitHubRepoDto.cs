namespace CV_Web.DTOS
{
    public class GitHubRepoDto
    {
        public string? Name { get; set; }
        public bool IsPrivate { get; set; }
        public string? HtmlUrl { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
