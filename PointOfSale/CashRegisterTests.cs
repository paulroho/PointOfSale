using FluentAssertions;
using Xunit;

namespace PointOfSale
{
	public class CashRegisterTests
	{
		private readonly CashRegister _cashRegister;

		public CashRegisterTests()
		{
			this._cashRegister = new CashRegister();
		}

		[Fact]
		public void SellOneRegisteredItem()
		{

			// Arrange
			_cashRegister.RegisterProduct(new Product("mybarcode", 123.45m));

			using (var monitoredCashRegister = _cashRegister.Monitor())
			{
				// Act
				_cashRegister.Scan("mybarcode");

				// Assert
				monitoredCashRegister.Should()
					.Raise(nameof(CashRegister.ProductSuccessfullyScanned))
					.WithArgs<ProductEventArgs>(e => e.Price == 123.45m);
			}
		}

		[Fact]
		public void DoesntSellNonRegisteredItem()
		{
			using (var monitoredCashRegister = _cashRegister.Monitor())
			{
				// Act
				_cashRegister.Scan("anotherbarcode");

				// Assert
				monitoredCashRegister.Should()
					.NotRaise(nameof(CashRegister.ProductSuccessfullyScanned));
			}
		}
	}
}