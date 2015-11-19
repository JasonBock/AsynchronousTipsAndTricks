using System.Threading.Tasks;

namespace ExaminingAsyncCode
{
	public interface IAsyncCode
	{
		Task<int> CalculateAsync();
		Task DoWorkAsync();
	}

	public class AsyncCodeWithAsync
		: IAsyncCode
	{
		public async Task<int> CalculateAsync()
		{
			return await Task.FromResult(44);
		}

		public async Task DoWorkAsync()
		{
			await Task.CompletedTask;
		}
	}

	public class AsyncCodeWithoutAsync
		: IAsyncCode
	{
		public Task<int> CalculateAsync()
		{
			return Task.FromResult(44);
		}

		public Task DoWorkAsync()
		{
			return Task.CompletedTask;
		}
	}
}
