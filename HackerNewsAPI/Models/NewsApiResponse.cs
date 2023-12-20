namespace HackerNewsAPI.Models;

public class NewsApiResponse
{
    public int id { get; set; }
    public string title { get; set; }
    public string url { get; set; }
    public string type { get; set; }
    public List<CommentApiResponse> children { get; set; }
}
