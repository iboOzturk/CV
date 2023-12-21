namespace CV_Web.DTOS
{
    public class GitHubRepoDto
    {
        public string? Name { get; set; }
        public bool IsPrivate { get; set; }
        public string? Html_Url { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
