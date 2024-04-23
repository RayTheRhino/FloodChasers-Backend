using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FloodChasersLogic.APIs
{
    public class WeatherApi : IWeatherApi

    {
        
        private const string ApiKey = "703f05a41c344fd698f74616232411";

        public async Task<List<AlertBoundary>> GetAlerts(string query,int days = 14,string getAlerts = "yes")
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"http://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={query}&alerts={getAlerts}&days={days}";
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
                    var result = new List<AlertBoundary>();
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        GetWeatherResponse weatherResponse = JsonSerializer.Deserialize<GetWeatherResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var alerts = weatherResponse?.Alerts;
                        if (alerts == null || !alerts.Alert.Any())
                        {
                            Console.WriteLine("No alerts found");
                        }
                        
                        foreach (var alert in alerts?.Alert)
                        {
                            if (string.IsNullOrEmpty(alert.Event) && alert.Event.Equals("Flood Warning"))
                            {
                                var alertBoundary = new AlertBoundary
                                {
                                    Location = new Location
                                    {
                                        Latitude = weatherResponse.Location.lat,
                                        Longitude = weatherResponse.Location.lon
                                    },
                                    Headline = alert.Headline,
                                    Id = Guid.NewGuid().ToString(),
                                    EffectiveTime = DateTime.Parse(alert.Effective),
                                    Areas = alert.Areas,
                                    Severity = alert.Severity,
                                    Description = alert.Desc
                                };
                                result.Add(alertBoundary);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get data. Status code: {response.StatusCode}");
                        throw new Exception($"Error: {responseBody}"); 
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message );
                    throw;
                }
            }
        }
    }
}
