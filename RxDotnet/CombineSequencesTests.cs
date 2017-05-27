using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class CombineSequencesTests
	{
		[Fact]
		public async Task MergeTests()
		{
			var observable1 = Observable.Interval(TimeSpan.FromSeconds(1));
			var observable2 = Observable.Interval(TimeSpan.FromSeconds(1))
				.Delay(TimeSpan.FromSeconds(2));

			var observable = observable1.Merge(observable2);

			observable.Subscribe(new LoggerObserver<long>());

			await Task.Delay(8000);
		}

		/// <summary>
		/// The amb operator only pushes those values of the sequences
		/// that is first to push values.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task AmbigiousTests()
		{
			var observable1 = Observable.Interval(TimeSpan.FromSeconds(1));
			var observable2 = Observable.Interval(TimeSpan.FromSeconds(1))
				.Delay(TimeSpan.FromSeconds(2));

			var observable = observable1.Amb(observable2);

			observable.Subscribe(new LoggerObserver<long>());

			await Task.Delay(8000);
		}
	}
}