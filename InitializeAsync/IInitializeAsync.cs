using System.Threading.Tasks;

namespace InitializeAsync
{
	public interface IInitializeAsync<T>
	{
		Task InitializeAsync(T parameter);
	}
}
