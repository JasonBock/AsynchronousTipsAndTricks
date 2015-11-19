using System;
using System.Threading.Tasks;
using InitializeAsync;

namespace UsingInitializeAsync
{
	public class Setup
		: IInitializeAsync<string>
	{
		public async Task InitializeAsync(string parameter)
		{
			await Task.Delay(10);
			this.Data = parameter;
		}

		public string Data { get; private set; }
	}
}

