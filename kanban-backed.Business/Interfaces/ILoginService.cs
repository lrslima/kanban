namespace kanban_backed.Business.Interfaces
{
	public interface ILoginService
	{
		Task<bool> Login(string username, string password);
	}
}

