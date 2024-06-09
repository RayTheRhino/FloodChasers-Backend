using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FloodChasersLogic.APIs
{
    public class AlertsApi : IAlertApi

    {
        public async Task<AlertBoundary> GetAlertsByLatLang(double lat,double lon)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"https://localhost:7233/Alerts/GetAlertByLocation?lat={lat}&lang={lon}";
                    var request = new HttpRequestMessage
                    {
                        // Set HTTP method and URL
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),

                    };
                    // Send the GET request and wait for the response
                    HttpResponseMessage response = await client.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = new AlertBoundary();
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        GetAlertLocResponse alertResponse = JsonSerializer.Deserialize<GetAlertLocResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var alert = alertResponse?.Alert;
                        if (alert == null)
                        {
                            Console.WriteLine("No alerts found");
                        }
                        return alert;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get data. Status code: {response.StatusCode}");
                        throw new Exception($"Error: {responseBody}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public async Task<List<AlertBoundary>> GetAllAlerts()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"https://localhost:7233/Alerts/GetAllalerts";
                    var request = new HttpRequestMessage
                    {
                        // Set HTTP method and URL
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),

                    };
                    // Send the GET request and wait for the response
                    HttpResponseMessage response = await client.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = new List<AlertBoundary>();
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        GetAlerstResponse alertResponse = JsonSerializer.Deserialize<GetAlerstResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var alerts = alertResponse?.Alerts;
                        if (alerts == null || !alerts.Any())
                        {
                            Console.WriteLine("No alerts found");
                        }
                        return alerts;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get data. Status code: {response.StatusCode}");
                        throw new Exception($"Error: {responseBody}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
