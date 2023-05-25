using System.Text.Json.Serialization;

namespace WebDevBackend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EventCategoryClass
    {
        EventCategoryOne = 1,
        EventCategoryTwo = 2,
        EventCategoryThree = 3
    }
}