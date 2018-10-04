using Xunit;

namespace PointOfSale
{
	public class CashRegisterTests
	{
		[Fact]
		public void SellOneRegisteredItem()
		{
			CashRegister cashRegister = null;

			// Arrange
			cashRegister.RegisterProduct("mybarcode", 123.45m);

			cashRegister.ProductSuccessfullyScanned += price =>
			{
				// Assert
				Assert.Equal(123.45m, price);
			};

			// Act
			cashRegister.Scan("mybarcode");
		}
	}
}