using System.Threading.Tasks;

namespace TestingAsyncCode
{
	public interface IProducer
	{
		Task<int> Produce();
	}
}
