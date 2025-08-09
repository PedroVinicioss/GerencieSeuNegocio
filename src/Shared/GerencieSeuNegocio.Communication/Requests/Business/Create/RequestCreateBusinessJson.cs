using GerencieSeuNegocio.Communication.Enums;

namespace GerencieSeuNegocio.Communication.Requests.Business.Create
{
    public class RequestCreateBusinessJson
    {
        public string Name { get; set; } = string.Empty;
        public BusinessTypeDto Type { get; set; }
    }
}
