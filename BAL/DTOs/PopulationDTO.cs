using Newtonsoft.Json;

namespace BAL.DTOs
{
    public class PopulationDTO
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("value")]
        public ulong Value { get; set; }
    }
}