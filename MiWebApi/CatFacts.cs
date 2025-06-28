using System.Text.Json.Serialization;

namespace catFacts
{
    public class CatFact
    {
        [JsonPropertyName("fact")]
        public string? Fact { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }
    }

}
