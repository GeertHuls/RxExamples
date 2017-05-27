using System;

namespace RxDotnet
{
	public class LoggerObserver<T> : IObserver<T>
	{
		public void OnCompleted()
		{
			Console.WriteLine("Sequence complete!");
		}

		public void OnError(Exception error)
		{
			Console.WriteLine("Sequence error!");
		}

		public void OnNext(T value)
		{
			Console.WriteLine($"value = {value}");
		}
	}
}