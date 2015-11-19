using System;
using System.Threading.Tasks;

namespace ExceptionsAndAsync
{
	class Program
	{
		static void Main(string[] args)
		{
#if DEBUG
			Console.Out.WriteLine("This won't work in a debug build.");
#else
			var notObserved = true;

			TaskScheduler.UnobservedTaskException += (s, e) =>
			{
				Console.Out.Write(" - Ha! I stopped you! -");
				e.SetObserved();
				//notObserved = false;
			};

			Task.Run(() => { throw new InvalidOperationException("test"); });

			while (notObserved)
			{
				Task.Delay(500);
				Console.Write("+");
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
#endif
		}
	}
}
