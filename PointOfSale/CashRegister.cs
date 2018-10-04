using System;

namespace PointOfSale
{
	public class CashRegister
	{
		private decimal _price;
		private string _barcode;

		public void RegisterProduct(string barcode, decimal price)
		{
			_barcode = barcode;
			_price = price;
		}

		public event EventHandler<ProductEventArgs> ProductSuccessfullyScanned;

		public void Scan(string barcode)
		{
			if (barcode.Equals(_barcode))
			{
				ProductSuccessfullyScanned?.Invoke(this, new ProductEventArgs(_price));
			}
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