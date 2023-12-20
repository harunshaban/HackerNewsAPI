namespace HackerNewsAPI.Models;

public class News
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Type { get; set; }
    public List<Comment> Comments { get; set; }

}
