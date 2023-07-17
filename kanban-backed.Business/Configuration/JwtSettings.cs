using System;
namespace kanban_backed.Business.Configuration
{
	public class JwtSettings
	{
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}

