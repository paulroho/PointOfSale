using System;
using FluentAssertions;
using FluentAssertions.Events;
using Xunit;

namespace PointOfSale
{
	public class CashRegisterTests : IDisposable
	{
		private readonly CashRegister _cashRegister;
		private readonly IMonitor<CashRegister> _monitoredCashRegister;

		public CashRegisterTests()
		{
			this._cashRegister = new CashRegister();
			_monitoredCashRegister = _cashRegister.Monitor();
		}

		public void Dispose()
		{
			_monitoredCashRegister.Dispose();
		}

		[Fact]
		public void SellOneRegisteredItem()
		{
			// Arrange
			var product = new Product("mybarcode", 123.45m);
			_cashRegister.RegisterProduct(product);

			// Act
			_cashRegister.Scan("mybarcode");

			// Assert
			AssertProductSuccessfullyScanned(product);
		}

		[Fact]
		public void DoesntSellNonRegisteredItem()
		{
			// Act
			_cashRegister.Scan("anotherbarcode");

			// Assert
			AssertProductNotSuccessfullyScanned();
		}

		private void AssertProductSuccessfullyScanned(Product expectedProduct)
		{
			_monitoredCashRegister.Should()
				.Raise(nameof(CashRegister.ProductSuccessfullyScanned))
				.WithArgs<ProductEventArgs>(e => e.Product.Price == expectedProduct.Price);
		}

		private void AssertProductNotSuccessfullyScanned()
		{
			_monitoredCashRegister.Should()
				.NotRaise(nameof(CashRegister.ProductSuccessfullyScanned));
		}
	}
}