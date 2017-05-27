using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class RxFilterOperatorTests
	{
		[Fact]
		public async Task FilterOperatorTest()
		{
			var sequence = Observable.Range(1, 10);
			var filteredSeq = sequence.Where(i => i % 2 == 0);

			filteredSeq.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task DistinctOperatorTest()
		{
			var sequence = new[] {1, 2, 3, 4, 1};
			var observable = sequence.ToObservable().Distinct();

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task DistinctUntilChangedOperatorTest()
		{
			var sequence = new[] { 1, 2, 2, 3, 4, 2 };
			var observable = sequence.ToObservable().DistinctUntilChanged();

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task TakeOperatorTest()
		{
			var sequence = new[] { 1, 2, 3, 4, 5 };
			var observable = sequence.ToObservable().Take(2);

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		[Fact]
		public async Task SkipOperatorTest()
		{
			var sequence = new[] { 1, 2, 3, 4, 5 };
			var observable = sequence.ToObservable().Skip(2);

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		/// <summary>
		/// SkipLast only work with observables that complete.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task SkipLastOperatorTest()
		{
			var sequence = new[] { 1, 2, 3, 4, 5 };
			var observable = sequence.ToObservable().SkipLast(2);

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}

		/// <summary>
		/// TakeLast only work with observables that complete.
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task TakeLastOperatorTest()
		{
			var sequence = new[] { 1, 2, 3, 4, 5 };
			var observable = sequence.ToObservable().TakeLast(2);

			observable.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}
	}
}