using System;
using System.IO;
using System.Threading.Tasks;

namespace ExaminingAsyncCode
{
	public sealed class UsingFileStream
	{
		public async Task Use()
		{
			using (var stream = new FileStream("somefile.txt", FileMode.CreateNew))
			{
				for(var i = 0; i < 1000; i++)
				{
					var buffer = Guid.NewGuid().ToByteArray();
					await stream.WriteAsync(buffer, 0, buffer.Length);
				}
			}
		}
	}
}
