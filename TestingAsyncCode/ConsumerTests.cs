using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rocks;
using System.Threading.Tasks;

namespace TestingAsyncCode
{
	[TestClass]
	public class ConsumerTests
	{
		[TestMethod]
		public async Task Consume()
		{
			const int value = 44;

			var rock = Rock.Create<IProducer>();
			rock.Handle(_ => _.Produce()).Returns(Task.FromResult<int>(value));

			var chunk = rock.Make();

			var consumer = new Consumer(chunk);
			Assert.AreEqual(value, await consumer.Consume());

			rock.Verify();
		}
	}
}
