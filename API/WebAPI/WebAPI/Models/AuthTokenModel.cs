using System;

namespace WebAPI.Models
{
    public class AuthTokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}