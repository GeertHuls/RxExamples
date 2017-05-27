using System.Reactive.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RxDotnet
{
	public class RxOperatorTests
	{
		[Fact]
		public async Task FilterOperatorTest()
		{
			var sequence = Observable.Range(1, 10);
			var filteredSeq = sequence.Where(i => i % 2 == 0);

			filteredSeq.Subscribe(new LoggerObserver<int>());

			await Task.Delay(5000);
		}
	}
}