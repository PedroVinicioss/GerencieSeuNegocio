﻿namespace GerencieSeuNegocio.Communication.Requests.Customer.Create
{
    public class RequestCreateCustomerJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
    }
}
