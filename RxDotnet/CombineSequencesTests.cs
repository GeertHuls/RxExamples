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

		/// <summary>
		/// Concat only works with finit observables.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task ConcatOperatorTests()
		{
			var observable1 = new[] { 1, 2, 3, 4, 5 }.ToObservable();
			var observable2 = new[] { 1, 2, 3, 4, 5 }.ToObservable();

			var observable = observable1.Concat(observable2);

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task CombineLatestTests()
		{
			var observable1 = new[] { 1, 2, 3, 4, 5 }.ToObservable();
			var observable2 = new[] { "1", "2", "3", "4", "5" }.ToObservable();

			var observable = observable1.CombineLatest(observable2, (x, y) => $"{x}-{y}");

			observable.Subscribe(new LoggerObserver<string>());

			await Task.Delay(5000);
		}

		/// <summary>
		/// Zip will wait for both new values before zipping them together.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task ZipTests()
		{
			var observable1 = new[] { 1, 2, 3, 4, 5 }.ToObservable();
			var observable2 = new[] { "1", "2", "3", "4", "5" }.ToObservable();

			var observable = observable1.Zip(observable2, (x, y) => $"{x}-{y}");

			observable.Subscribe(new LoggerObserver<string>());

			await Task.Delay(5000);
		}
	}
}