using System;
using Newtonsoft.Json;

namespace mariopi
{
    public class TemperatureDto 
    {
        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }
    }
}