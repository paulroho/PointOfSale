using System;

namespace PointOfSale
{
	public class CashRegister
	{
		public void RegisterProduct(string barcode, decimal price)
		{
		}

		public event EventHandler<ProductEventArgs> ProductSuccessfullyScanned;

		public void Scan(string barcode)
		{
		}
	}

	public class ProductEventArgs : EventArgs
	{
		public ProductEventArgs(decimal price)
		{
			Price = price;
		}

		public decimal Price { get; }
	}
}