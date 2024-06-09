using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FloodChasersLogic.APIs
{
    public class ArticleApi : IArticleApi
    {
        private const string ApiKey = "7a083152bef443358f12e1c72d152061";
        public async Task<List<LearnBoundary>> GetArticlesBySubject(string subject)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Specify the URL you want to send the request to
                    DateTime date = DateTime.Now;
                    var requestDate = date.AddDays(-30).Date;
                    string url = $"https://newsapi.org/v2/everything?q={subject}&from={requestDate}&sortBy=popularity&apiKey={ApiKey}";
                    var userAgent = "MyApi";
                    var request = new HttpRequestMessage
                    {
                        // Set HTTP method and URL
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),

                        // Add headers to the request
                        Headers =
                        {
                            // Add the User-Agent header
                            { "User-Agent", userAgent }
                        }
                    };
                    // Send the GET request and wait for the response
                    HttpResponseMessage response = await client.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        GetArticlesResponse articleResponse = JsonSerializer.Deserialize<GetArticlesResponse>(responseBody,new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                        var articles = articleResponse?.Articles;
                        
                        if (articles == null)
                        {
                            Console.WriteLine("I am null");
                        }
                        return articles;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get data. Status code: {response.StatusCode}");
                        throw new Exception($"Error: {responseBody}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
