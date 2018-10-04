using FluentAssertions;
using Xunit;

namespace PointOfSale
{
	public class CashRegisterTests
	{
		[Fact]
		public void SellOneRegisteredItem()
		{
			var cashRegister = new CashRegister();
			var eventOccured = false;

			// Arrange
			cashRegister.RegisterProduct("mybarcode", 123.45m);

			cashRegister.ProductSuccessfullyScanned += (_, e) =>
			{
				eventOccured = true;
				// Assert
				e.Price.Should().Be(123.45m);
			};

			// Act
			cashRegister.Scan("mybarcode");

			// Assert
			eventOccured.Should().BeTrue();
		}
	}
}