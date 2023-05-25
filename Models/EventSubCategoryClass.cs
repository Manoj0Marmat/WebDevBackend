using System.Text.Json.Serialization;

namespace WebDevBackend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EventSubCategoryClass
    {
        EventSubCategoryOne = 1,
        EventSubCategoryTwo = 2,
        EventSubCategoryThree = 3
    }
}