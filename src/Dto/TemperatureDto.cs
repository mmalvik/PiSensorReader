using System;
using Newtonsoft.Json;

namespace PiSensorReader
{
    public class TemperatureDto 
    {
        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }
    }
}