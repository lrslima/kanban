namespace kanban_backed.Business.Interfaces
{
	public interface IJwtTokenService
	{
        string GenerateToken(string user);
        string ValidateToken(string token);
    }
}

