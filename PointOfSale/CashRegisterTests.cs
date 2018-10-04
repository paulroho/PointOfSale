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
				Assert.Equal(123.45m, e.Price);
			};

			// Act
			cashRegister.Scan("mybarcode");

			// Assert
			Assert.True(eventOccured, $"The event {nameof(CashRegister.ProductSuccessfullyScanned)} has not occured.");
		}
	}
}