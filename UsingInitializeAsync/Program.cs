using System;

namespace UsingInitializeAsync
{
	class Program
	{
		static void Main(string[] args)
		{
			var setup = new Setup();
			setup.InitializeAsync("a").Wait();
			Console.Out.WriteLine(setup.Data);
		}
	}
}
