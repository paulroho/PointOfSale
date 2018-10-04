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

			// Arrange
			cashRegister.RegisterProduct("mybarcode", 123.45m);

			using (var monitoredCashRegister = cashRegister.Monitor())
			{
				// Act
				cashRegister.Scan("mybarcode");

				// Assert
				monitoredCashRegister.Should()
					.Raise(nameof(CashRegister.ProductSuccessfullyScanned))
					.WithArgs<ProductEventArgs>(e => e.Price == 123.45m);
			}
		}
	}
}