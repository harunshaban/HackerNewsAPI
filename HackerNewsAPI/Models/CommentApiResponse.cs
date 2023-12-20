namespace HackerNewsAPI.Models;

public class CommentApiResponse
{
    public string author { get; set; }
    public string text { get; set; }
    public DateTime created_at { get; set; }
    public List<CommentApiResponse> children { get; set; }
}
