using System;

namespace PointOfSale
{
	public class CashRegister
	{
		private Product _product;

		public void RegisterProduct(Product product)
		{
			_product = product;
		}

		public event EventHandler<ProductEventArgs> ProductSuccessfullyScanned;

		public void Scan(string barcode)
		{
			var product = FindProduct(barcode);
			if (product != null)
			{
				ProductSuccessfullyScanned?.Invoke(this, new ProductEventArgs(product));
			}

		}

		private Product FindProduct(string barcode)
		{
			if (ProductExists(barcode))
			{
				return _product;
			}

			return null;
		}

		private bool ProductExists(string barcode)
		{
			return _product?.Barcode == barcode;
		}
	}
}