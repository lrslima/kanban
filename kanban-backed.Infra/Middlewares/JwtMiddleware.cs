using System;
using System.Net.Http;
using kanban_backed.Business.Interfaces;
using Microsoft.AspNetCore.Http;

namespace kanban_backed.Infra
{
	public class JwtMiddleware
	{
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtTokenService jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();   
            var user = jwtUtils.ValidateToken(token);
            if (user != null)
            {
                context.Items["User"] = user;
            }

            await _next(context);
        }
    }
}

