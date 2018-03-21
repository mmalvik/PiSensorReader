using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace PiSensorReader
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            ReadConfiguration();
            
            var temperature = ReadTemperature();

            PostTemperature(temperature);
        }

        private static void ReadConfiguration() 
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            if (string.IsNullOrEmpty(Configuration["TemperatureUrl"]) || string.IsNullOrEmpty(Configuration["AzureFunctionAuthKey"]))
            {
                throw new ArgumentNullException("Configuration could not be read");
            }
        }

        private static TemperatureDto ReadTemperature() 
        {
            var random = new Random();
            var randomTemp = random.Next(-20, 20);

            return new TemperatureDto{ Temperature = randomTemp, TimeStamp = DateTime.Now };
        }

        private static void PostTemperature(TemperatureDto temperatureDto) 
        {
            var json = JsonConvert.SerializeObject(temperatureDto);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Configuration["TemperatureUrl"]);
            requestMessage.Headers.Add("x-functions-key", new List<string>() { Configuration["AzureFunctionAuthKey"] });
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var httpClient = new HttpClient();
            httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
        }
    }
}
