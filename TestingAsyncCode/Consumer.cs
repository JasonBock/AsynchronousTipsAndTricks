using System.Threading.Tasks;

namespace TestingAsyncCode
{
	public class Consumer
	{
		private readonly IProducer producer;

		public Consumer(IProducer producer)
		{
			this.producer = producer;
		}

		public async Task<int> Consume()
		{
			return await this.producer.Produce();
		}
	}
}
