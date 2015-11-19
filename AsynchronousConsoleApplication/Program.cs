using Nito.AsyncEx;
using System.Threading.Tasks;

namespace AsynchronousConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			AsyncContext.Run(Program.MainAsync);
		}

		private static async Task MainAsync()
		{
			await Task.Delay(100).ConfigureAwait(false);
		}
	}
}
