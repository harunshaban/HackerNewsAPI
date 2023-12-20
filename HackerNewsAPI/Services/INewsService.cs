using HackerNewsAPI.Models;

namespace HackerNewsAPI.Services;

public interface INewsService
{
    Task<List<HackerNewsApiResponse.Hit>> GetNews(string filter, string query);
    Task<List<HackerNewsApiResponse.Hit>> GetNewsByDate(string filter, string query);
    Task<News> GetNewsDetails(int newsId);
}
