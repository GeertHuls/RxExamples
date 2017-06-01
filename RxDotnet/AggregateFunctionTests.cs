using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class AggregateFunctionTests
	{
		[Fact]
		public async Task CanCalculateSum()
		{
			var observable = new[] {1, 2, 3, 4, 5}.ToObservable();

			observable.Aggregate((acc, val) => acc + val)
				.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task CanScanSumOfValues()
		{
			var observable = Observable.Interval(TimeSpan.FromSeconds(1));

			observable.Scan((acc, val) => acc + val)
				.Subscribe(new LoggerObserver<long>());

			await Task.Delay(10000);
		}
	}
}