using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class RxDotnetTests
	{
		[Fact]
		public void SimpleObservables()
		{
			// This doesn't push any values and ends
			// .............|
			Observable.Empty<int>();

			// This doesn't push any value but won't ever end
			// ...................
			Observable.Never<int>();

			// Throws an exceptions and stops the sequence:
			// .............X
			Observable.Throw<int>(new InvalidOperationException());

			// Returns only 1 value in the stream and then stops:
			// ......42......|
			Observable.Return("42");
		}

		[Fact]
		public async Task ObservableWrappers()
		{
			// Action observerable, sequence ends after action.
			// ......42......|
			await Observable.Start(() => 42);

			// Wrap observables around tasks:
			// ..............|
			await Task.Delay(200).ToObservable();

			// Wrap observable around IEnumerables:
			// ...1.2.3.4.5.6.|
			IEnumerable<int> numbers = new[] {1, 2, 3, 4, 5, 6};
			await numbers.ToObservable();

			// Wrap observable around (click) events:
			// .....a......b....|
			// Observable.FromEventPattern(searchTextbox, "TextChanged");
		}

		[Fact]
		public async Task GenerationFunctions()
		{
			// Range functions
			// ...1.2.3.4....|
			await Observable.Range(1, 4);

			// Interval, Timer functions
			// ...a.......b.......c........
			await Observable.Interval(TimeSpan.FromSeconds(5));
			// ...a.......b.......c........
			await Observable.Timer(TimeSpan.FromSeconds(5));

			// Create, generate functions
			// ......42......|
			await Observable.Create<int>(o =>
			{
				o.OnNext(42);
				o.OnCompleted();
				return Disposable.Empty;
			});

			// Generate functions do net neccessarly have to finish,
			// they can be infinite too.
			// ...1.2.3.4....|
			await Observable.Generate(1,
				value => value < 5,
				value => value + 1,
				value => value);
		}
	}
}
