namespace HackerNewsAPI.Models;

public class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Comment> Children { get; set; }
}
