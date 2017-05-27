using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class SequenceValvesOperatorTests
	{
		[Fact]
		public async Task TakeUntilOperatorTest()
		{
			var observable1 = Observable.Interval(TimeSpan.FromSeconds(1));
			var observable2 = Observable.Interval(TimeSpan.FromSeconds(1))
				.Delay(TimeSpan.FromSeconds(3));

			var observable = observable1.TakeUntil(observable2);

			observable.Subscribe(new LoggerObserver<long>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task SkipUntilOperatorTest()
		{
			var observable1 = Observable.Interval(TimeSpan.FromSeconds(1));
			var observable2 = Observable.Interval(TimeSpan.FromSeconds(1))
				.Delay(TimeSpan.FromSeconds(3));

			var observable = observable1.SkipUntil(observable2);

			observable.Subscribe(new LoggerObserver<long>());

			await Task.Delay(8000);
		}
	}
}