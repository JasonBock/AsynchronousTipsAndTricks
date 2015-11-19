using System;
using System.Collections.Immutable;

namespace UsingImmutableCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			var things = new[] { "a", "b", "c" }.ToImmutableList();
			Console.Out.WriteLine($"{string.Join(", ", things)}");
			things = things.Add("d");
			Console.Out.WriteLine($"{string.Join(", ", things)}");

			var thingsBuilder = things.ToBuilder();
			thingsBuilder.RemoveAt(2);
			thingsBuilder.Add("e");

			things = thingsBuilder.ToImmutable();
			Console.Out.WriteLine($"{string.Join(", ", things)}");
		}
	}
}
