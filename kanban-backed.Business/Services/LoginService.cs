using System;
using kanban_backed.Business.Configuration;
using kanban_backed.Business.Interfaces;

namespace kanban_backed.Business.Services
{
	public class LoginService : ILoginService
    {
        private readonly AuthSettings _authSettings;

        public LoginService(AuthSettings authSettings)
        {
            _authSettings = authSettings;
        }

        public Task<bool> Login(string username, string password)
        {
            try
            {
                bool isValidCredentials = username == _authSettings.ValidLogin && password == _authSettings.ValidPassword;

                return Task.FromResult(isValidCredentials);
            }
            catch (Exception ex)
            {
                // Lida com exceções (caso necessário)
                return Task.FromException<bool>(ex);
            }
        }
    }
}

