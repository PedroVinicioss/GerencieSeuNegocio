using GerencieSeuNegocio.Communication.Enums;

namespace GerencieSeuNegocio.Communication.Responses.Business.Create
{
    public class ResponseCreateBusinessJson
    {
        public string Name { get; set; } = string.Empty;
        public BusinessTypeDto Type { get; set; }
    }
}
