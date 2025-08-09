using System.Text.Json.Serialization;

namespace GerencieSeuNegocio.Communication.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BusinessTypeDto
    {
        Store,
        Hotel,
        Restaurant
    }
}
