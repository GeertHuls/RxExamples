using System;
using System.Reactive.Linq;
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
    }
}
