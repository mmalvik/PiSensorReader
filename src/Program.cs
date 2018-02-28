using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace mariopi
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var url = "http://www.vg.no";
            var statusCode = httpClient.GetAsync(url).Result.StatusCode;

            var temp = new TemperatureDto{ Temperature = 20, TimeStamp = DateTime.Now };
            var json = JsonConvert.SerializeObject(temp);

            Console.WriteLine("Hello from .NetCore");
            Console.WriteLine($"Statuscode: {statusCode}  Url: {url}");
            Console.WriteLine(json);
        }
    }
}
