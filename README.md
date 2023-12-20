# HackerNewsAPI

Get details for selected news and the associated comments;
(Call the api: {{hostname}}/GetNewsDetails?newsId=1)

Getting a list of news;

Support for news filtering:
   - newest to oldest(All);
     {{hostname}}/GetNewsByDate?filter=story
   - sorted by voting(Hot); 
      There is no referance for sorting by voting(HOT).
   - Show HN(news that starts with Show HN:);
      {{hostname}}/GetNewsByDate?filter=show_hn
   - Ask HN(news that starts with Ask HN);
      {{hostname}}/GetNewsByDate?filter=ask_hn

Search for news based on keywords;
{{hostname}}/GetNews?query=OpenAI
