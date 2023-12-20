using HackerNewsAPI.Models;
using Newtonsoft.Json;

namespace HackerNewsAPI.Services;

public class NewsService : INewsService
{
    private readonly HttpClient _httpClient;

    public NewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<HackerNewsApiResponse.Hit>> GetNewsByDate(string filter, string query)
    {
        string apiUrl = "https://hn.algolia.com/api/v1/search_by_date";

        string queryString = $"?tags={filter}&query={query}";

        HttpResponseMessage response = await _httpClient.GetAsync($"{apiUrl}{queryString}");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HackerNewsApiResponse>(jsonResponse);

            return result.hits.Select(hit => new HackerNewsApiResponse.Hit
            {
                story_id = hit.story_id,
                title = hit.title,
                url = apiUrl,
                points = hit.points,
                created_at = hit.created_at,
            }).ToList();


        }
        else { throw new Exception("Unsuccessfull Response"); }
    }

    public async Task<List<HackerNewsApiResponse.Hit>> GetNews(string filter, string query)
    {
        string apiUrl = "https://hn.algolia.com/api/v1/search";

        string queryString = $"?tags={filter}&query={query}";

        HttpResponseMessage response = await _httpClient.GetAsync($"{apiUrl}{queryString}");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HackerNewsApiResponse>(jsonResponse);

            return result.hits.Select(hit => new HackerNewsApiResponse.Hit
            {
                story_id = hit.story_id,
                title = hit.title,
                url = apiUrl,
                points = hit.points,
                created_at = hit.created_at,
            }).ToList();


        }
        else { throw new Exception("Unsuccessfull Response"); }
    }

    public async Task<News> GetNewsDetails(int newsId)
    {
        string apiUrl = "https://hn.algolia.com/api/v1/items";

        HttpResponseMessage response = await _httpClient.GetAsync($"{apiUrl}/{newsId}");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NewsApiResponse>(jsonResponse);

            return new News
            {
                Id = result.id,
                Title = result.title,
                Url = result.url,
                Type = result.type,
                Comments = MapComments(result.children)
            };
        }
        else { throw new Exception("Unsuccessfull Response"); }
    }

    private List<Comment> MapComments(List<CommentApiResponse> comments)
    {
        if (comments == null)
            return null;

        return comments.Select(comment => new Comment
        {
            Author = comment.author,
            Text = comment.text,
            CreatedAt = comment.created_at,
            Children = MapComments(comment.children)
        }).ToList();
    }

}
