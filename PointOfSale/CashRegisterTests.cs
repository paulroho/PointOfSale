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
			_cashRegister = new CashRegister(new Inventory());
			_monitoredCashRegister = _cashRegister.Monitor();
		}

		public void Dispose()
		{
			_monitoredCashRegister.Dispose();
		}

		[Fact]
		public void ScanOneRegisteredItem()
		{
			var product = new Product("mybarcode", 123.45m);
			_cashRegister.RegisterProduct(product);

			// Act
			_cashRegister.Scan("mybarcode");

			AssertProductSuccessfullyScanned(product);
		}

		[Fact]
		public void ScanNotRegisteredItem()
		{
			// Act
			_cashRegister.Scan("anotherbarcode");

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