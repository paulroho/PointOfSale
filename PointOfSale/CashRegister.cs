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
			if (_product?.Barcode == barcode)
			{
				ProductSuccessfullyScanned?.Invoke(this, new ProductEventArgs(_product));
			}
		}
	}
}