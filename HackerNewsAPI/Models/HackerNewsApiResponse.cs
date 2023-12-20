namespace HackerNewsAPI.Models;

public class HackerNewsApiResponse
{
    public List<Hit> hits { get; set; }

    public class Hit
    {
        public int story_id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string points { get; set; }
        public DateTime created_at { get; set; }
        //public List<CommentApiResponse> children { get; set; }
    }
}
