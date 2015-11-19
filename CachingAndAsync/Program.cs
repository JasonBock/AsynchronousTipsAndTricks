using System;
using System.Threading.Tasks;

namespace CachingAndAsync
{
	class Program
	{
		private const string Key = "data";

		static void Main(string[] args)
		{
			Console.Out.WriteLine(Program.GetDataAsync().Result);
			Console.Out.WriteLine(Program.GetCompletedDataAsync().Result);
		}

		private static async Task<string> GetDataAsync()
		{
			await Task.Delay(1000);
			return Guid.NewGuid().ToString();
		}

		private static Task<string> GetCompletedDataAsync()
		{
			return Task.FromResult<string>(Guid.NewGuid().ToString());
		}
	}
}
