using HackerNewsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAPI.Controllers;

public class NewsController : Controller
{

    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    /// <summary>
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetNews")]
    public async Task<IActionResult> GetNews(string filter, string query)
    {
        var news = await _newsService.GetNews(filter, query);
        return Ok(news);
    }

    /// <summary>
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetNewsByDate")]
    public async Task<IActionResult> GetNewsByDate(string filter, string query)
    {
        var news = await _newsService.GetNewsByDate(filter, query);
        return Ok(news);
    }

    /// <summary>
    /// </summary>
    /// <param name="newsId"></param>
    /// <returns></returns>
    [HttpGet("GetNewsDetails")]
    public async Task<IActionResult> GetNewsDetails(int newsId)
    {
        var newsDetails = await _newsService.GetNewsDetails(newsId);
        return Ok(newsDetails);
    }
}
